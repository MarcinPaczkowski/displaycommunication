using System.IO.Ports;
using System.Linq;

namespace DisplayCommon.Models
{
    public class SerialPortToken
    {
        private static readonly SerialPortToken _instance = new SerialPortToken();

        private readonly SerialPort _serialPort;

        static SerialPortToken()
        {
        }

        private SerialPortToken()
        {
            _serialPort = new SerialPort();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            _serialPort.BaudRate = 9600;
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.ReadTimeout = 5000;
            _serialPort.WriteTimeout = 2000;
        }

        public static SerialPortToken Instance
        {
            get
            {
                return _instance;
            }
        }

        public SerialPort GetSerialPort()
        {
            return _serialPort;
        }

        public bool CheckIfSerialPortIsAvailable(string serialPortName)
        {
            var availableSerialPorts = SerialPort.GetPortNames().ToList();
            return availableSerialPorts.Any(a => a.Equals(serialPortName));
        }

        public void ConnectToSerialPort(string serialPortName)
        {
            _serialPort.PortName = serialPortName;
            _serialPort.Close();
            _serialPort.Open();
        }

        public void DisconnectSerialPort()
        {
            _serialPort.Close();
        }
    }
}
