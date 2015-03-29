using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using DisplayExtensions.Enums;
using DisplayExtensions.Models;
using DisplayExtensions.Services;

namespace DisplayTest.Forms
{
    public partial class MainForm : Form
    {
        private DisplayService _displayService;
        public MainForm()
        {
            InitializeComponent();
            _displayService = new DisplayService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            uxSerialPorts.Items.AddRange(GetSerialPorts());
        }

        private static string[] GetSerialPorts()
        {
            return SerialPort.GetPortNames();
        }

        private void uxGetDisplayStatus_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(uxSerialPorts.SelectedItem.ToString()))
                return;
            var selectedSerialPort = uxSerialPorts.SelectedItem.ToString();
            uxSerialPort.PortName = selectedSerialPort;

            try
            {
                uxSerialPort.Close();
                uxSerialPort.Open();
                var answer = _displayService.IsReadyToWrite(uxSerialPort);
                if (!answer)
                    throw new Exception("Urządzenie nie jest gotowe do wysłania wiadomości");

                var display = new Display
                {
                    FullCommand = "<J127><T5><CR><CL><S030         ><CG><S2110        ><P10>"
                };

                display.FrameWithText = _displayService.CreateFrameWithText(display, Mode.InputText);
                var isSendCorrectFirst = _displayService.WriteBytes(uxSerialPort, display.FrameWithText);

                display.FrameForEndText = _displayService.CreateFrameForEndText();
                var isSendCorrectLast = _displayService.WriteBytes(uxSerialPort, display.FrameForEndText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                uxSerialPort.Close();
            }
        }
    }
}
