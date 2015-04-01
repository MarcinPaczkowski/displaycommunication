using System;
using DisplayCommon.Models;
using DisplayCommon.Utils;
using DisplayCommunication.Repositories;
using DisplayExtensions.Enums;
using DisplayExtensions.Models;
using DisplayExtensions.Services;

namespace DisplayCommunication.Services
{
    internal class MainService
    {
        private readonly DisplayRepository _displayRepository = new DisplayRepository();
        private readonly DisplayService _displayService = new DisplayService();
        private readonly DisplayCommandFabric _displayCommandFabric = new DisplayCommandFabric();

        private int _messageId;
        private Display _display;
        private const int Counter = 10;

        internal void TryDisplayMessage(int messageId)
        {
            _messageId = messageId;
            _display = _displayRepository.SelectDisplayMessage(_messageId);
            _display.FullCommand = _displayCommandFabric.CreateDisplayCommand(_display.Command);

            lock (SerialPortToken.Instance)
            {
                try
                {
                    if (!SerialPortToken.Instance.CheckIfSerialPortIsAvailable(_display.SerialPortName))
                        throw new Exception(String.Format("Port {0} jest niedostępny.", _display.SerialPortName));

                    SerialPortToken.Instance.ConnectToSerialPort(_display.SerialPortName);

                    var counter = 0;
                    var serialPort = SerialPortToken.Instance.GetSerialPort();
                    while (!_displayService.IsReadyToWrite(serialPort, _display.DisplayAddress) || counter >= Counter)
                        counter++;
                    if (counter >= Counter)
                        throw new Exception("Nie można wysłać ramki do wyświetlacza.");

                    var frameWithCommand = _displayService.CreateFrameWithText(_display, Mode.InputText);
                    _displayService.WriteBytes(serialPort, frameWithCommand);

                    var frameForEndText = _displayService.CreateFrameForEndText();
                    _displayService.WriteBytes(serialPort, frameForEndText);
                }
                finally
                {
                    SerialPortToken.Instance.DisconnectSerialPort();
                }
            }
        }
    }
}
