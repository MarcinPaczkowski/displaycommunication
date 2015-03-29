using System.Collections.Generic;

namespace DisplayExtensions.Models
{
    public class Display
    {
        public int DisplayId { get; set; }
        public byte DisplayAddress { get; set; }
        public string SerialPortName { get; set; }
        public string Command { get; set; }
        public string FullCommand { get; set; }
        public List<byte> FrameWithText { get; set; }
        public List<byte> FrameForEndText { get; set; }

        public Display()
        {
            FrameWithText = new List<byte>();
            FrameForEndText = new List<byte>();
        }

    }
}
