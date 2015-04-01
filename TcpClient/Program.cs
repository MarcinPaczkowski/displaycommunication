using System;
using System.Linq;
using System.Text;
using TcpClient.Properties;
using log4net;
using log4net.Config;

namespace TcpClient
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            try
            {
                XmlConfigurator.Configure();
                if (!args.Any())
                    throw new Exception("Program został wystartowany bez argumentu");
                var port = Settings.Default.Port;
                var host = Settings.Default.IpAddress;
                var client = new System.Net.Sockets.TcpClient(host, port);
                var data = Encoding.ASCII.GetBytes(args[0]);
                var stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                if (Settings.Default.LoggingEnable)
                {
                    Log.Error(ex.Message);
                    if (ex.InnerException != null)
                        Log.Error(ex.InnerException.Message);
                }
            }
        }
    }
}
