using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using DisplayCommon.Utils;
using DisplayCommunication.Properties;
using DisplayCommunication.Services;
using log4net;
using log4net.Config;

namespace DisplayCommunication.Console
{
    public class Program
    {
        private static MainService _mainService;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main()
        {
            try
            {
                XmlConfigurator.Configure();
                LoadConfigurationFiles();

                _mainService = new MainService();
                var port = Settings.Default.Port;
                var localAddr = IPAddress.Parse(Settings.Default.IpAddress);

                var server = new TcpListener(localAddr, port);
                server.Stop();
                DisplayMessage(String.Format("Rozpoczęto nasłuchiwanie - {0}:{1}", localAddr, port));

                while (true)
                {
                    server.Start();
                    ListenTcpAndDisplayMessage(server);
                    server.Stop();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
                if (Settings.Default.LoggingEnable)
                {
                    Log.Error(ex.Message);
                    if (ex.InnerException != null)
                        Log.Error(ex.InnerException.Message);
                }
            }
        }

        private static void ListenTcpAndDisplayMessage(TcpListener server)
        {
            var client = server.AcceptTcpClient();
            var bytes = new byte[64];

            try
            {
                var stream = client.GetStream();
                while (stream.Read(bytes, 0, bytes.Length) != 0)
                {
                    var fullMessage = Encoding.ASCII.GetString(bytes);
                    var splittedMessage = fullMessage.Split(';');

                    var displayMessage = splittedMessage[0];
                    var signMessage = splittedMessage[1];

                    _mainService.TryDisplayMessage(displayMessage, signMessage);
                    DisplayMessage(String.Format("Udana operacja wyświetlenia wiadomości dla wiadomości {0}", displayMessage));
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
                if (!Settings.Default.LoggingEnable)
                    return;
                Log.Error(ex.Message);
                if (ex.InnerException != null)
                    Log.Error(ex.InnerException.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private static void LoadConfigurationFiles()
        {
            Configuration.Instance.LoadAdditionalEffectsConfiguration("ExtensionDisplayConfiguration.txt");
            Configuration.Instance.LoadSqlConfiguration("Configuration.xml");
        }

        private static void DisplayMessage(string message)
        {
            System.Console.WriteLine(@"{0} - {1}", DateTime.Now, message);
        }
    }
}
