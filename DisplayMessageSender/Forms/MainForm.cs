using System;
using System.IO.Ports;
using System.Windows.Forms;
using DisplayCommon.Models;
using DisplayExtensions.Enums;
using DisplayExtensions.Services;
using DisplayExtensions.Models;

namespace DisplayMessageSender.Forms
{
    public partial class MainForm : Form
    {
        private readonly DisplayService _displayService;
        public MainForm()
        {
            InitializeComponent();
            _displayService = new DisplayService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ReSharper disable once CoVariantArrayConversion
            uxSerialPorts.Items.AddRange(GetSerialPorts());
            if (uxSerialPorts.Items.Count > 0)
                uxSerialPorts.SelectedIndex = 0;
        }

        private static string[] GetSerialPorts()
        {
            return SerialPort.GetPortNames();
        }

        private void uxSendMessage_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(uxSerialPorts.SelectedItem.ToString()))
                return;

            lock (SerialPortToken.Instance)
            {
                try
                {
                    var selectedSerialPort = uxSerialPorts.SelectedItem.ToString();
                    SerialPortToken.Instance.ConnectToSerialPort(selectedSerialPort);
                    var serialPort = SerialPortToken.Instance.GetSerialPort();

                    var display = new Display
                    {
                        DisplayAddress = 0x20,
                        SerialPortName = serialPort.PortName,
                        FullCommand = uxMessage.Text
                    };

                    var isReady = _displayService.IsReadyToWrite(serialPort, display.DisplayAddress);
                    if (!isReady)
                        throw new Exception("Urządzenie nie jest gotowe do wysłania wiadomości");

                    var selectedMode = uxMode.Checked ? Mode.DefaultText : Mode.InputText;

                    var frameWithCommand = _displayService.CreateFrameWithText(display, selectedMode);
                    _displayService.WriteBytes(serialPort, frameWithCommand);

                    var frameForEndText = _displayService.CreateFrameForEndText();
                    _displayService.WriteBytes(serialPort, frameForEndText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Błąd w trakcie wysyłania wiadomości", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SerialPortToken.Instance.DisconnectSerialPort();
                }
            }
        }
    }
}
