using System;
using DisplayCommunication.Services;

namespace DisplayCommunication.Console
{
    public class Program
    {
        private static MainService _mainService;

        static void Main(string[] args)
        {
            try
            {
                var messageId = Convert.ToInt32(args[0]);
                _mainService = new MainService();
                _mainService.TryDisplayMessage(messageId);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.ReadKey();
            }
        }
    }
}
