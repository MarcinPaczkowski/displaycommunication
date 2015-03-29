using System;
using System.Linq;
using DisplayCommunication.Properties;
using DisplayCommunication.Services;
using log4net;
using log4net.Config;

namespace DisplayCommunication.Console
{
    public class Program
    {
        private static MainService _mainService;
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            try
            {
                XmlConfigurator.Configure();
                if (!args.Any())
                    throw new Exception("Nie podano parametru id wiadomości przy wywoływaniu programu.");
                var messageId = Convert.ToInt32(args[0]);
                _mainService = new MainService();
                _mainService.TryDisplayMessage(messageId);
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
