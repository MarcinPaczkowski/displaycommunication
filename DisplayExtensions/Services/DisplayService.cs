using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using DisplayExtensions.Enums;
using DisplayExtensions.Models;

namespace DisplayExtensions.Services
{
    public class DisplayService
    {
        public byte WriteBytes(SerialPort serialPort, List<byte> frame)
        {
            serialPort.Write(frame.ToArray(), 0, frame.Count);
            var displayAnswer = new byte[1];
            serialPort.Read(displayAnswer, 0, 1);
            return displayAnswer[0];
        }

        public bool IsReadyToWrite(SerialPort serialPort, byte displayAddress = 0x20)
        {
            var frame = new List<byte> { (byte)SpecialByte.Syn, displayAddress };
            serialPort.Write(frame.ToArray(), 0, frame.Count);
            var displayAnswer = new byte[2];
            serialPort.Read(displayAnswer, 0, 2);
            var answer = (displayAnswer[0] == displayAddress) && (displayAnswer[1] == (byte) StatusDevice.Ok);
            return answer;
        }

        public List<byte> CreateFrameWithText(Display display, Mode mode)
        {
            var frame = new List<byte>();

            frame.AddRange(GetFirstPartFrame(mode));
            frame.AddRange(ConvertToAsci(display.FullCommand));
            frame.AddRange(GetLastPartFrame());
            var crc = GetCrc(frame);
            frame.Insert(frame.Count() - 1, crc);

            return frame;
        }

        public List<byte> CreateFrameForEndText()
        {
            const byte crc = 0xFE;
            return new List<byte>
            { 
                (byte)SpecialByte.Enq, (byte)SpecialByte.Esc, (byte)Command.EndText, crc, (byte)SpecialByte.Eot
            };
        }

        private static IEnumerable<byte> ConvertToAsci(string message)
        {
            return Encoding.ASCII.GetBytes(message).ToList();
        }

        private static IEnumerable<byte> GetFirstPartFrame(Mode mode)
        {
            var thirdByte = (mode == Mode.InputText ? (byte) Command.StartText : (byte) Command.DefaultText);
            return new List<byte>
            {
                (byte)SpecialByte.Enq, (byte)SpecialByte.Esc, thirdByte, 
                (byte)SpecialByte.Esc, (byte)Command.Zero, (byte)SpecialByte.Esc, (byte)Command.Zero
            };
        }

        private static IEnumerable<byte> GetLastPartFrame()
        {
            return new List<byte>
            {
                0x00, (byte)SpecialByte.Esc, (byte)Command.Zero, (byte)SpecialByte.Eot
            };
        }

        private static byte GetCrc(IEnumerable<byte> bytes)
        {
            var bytesWithoutFirstAndLastByte = bytes.Skip(1).Reverse().Skip(1).Reverse().ToList();
            var sum = 0;
            var isSpecialMode = false;

            foreach (var oneByte in bytesWithoutFirstAndLastByte)
            {
                if (oneByte == (byte)SpecialByte.Esc)
                    isSpecialMode = true;

                else if (isSpecialMode)
                {
                    var tmpByte = (int)oneByte;
                    tmpByte = ~tmpByte;
                    sum = sum + (byte)tmpByte;
                    isSpecialMode = false;
                }

                else
                    sum += oneByte;
            }

            var crc = ~(sum & 0xFF) + 1;
            return (byte)crc;
        }
    }
}
