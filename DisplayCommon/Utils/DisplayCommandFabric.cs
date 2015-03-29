using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DisplayCommon.Models;

namespace DisplayCommon.Utils
{
    public class DisplayCommandFabric
    {
        public string CreateDisplayCommand(string command)
        {
            var values = GetValuesFromCommand(command);
            var messageType = GetMessageType(command, values);
            var messageTypeString = messageType.ToString().ToUpper();

            var additionalEffects = Configuration.Instance.GetAdditionalEffects();
            if (additionalEffects == null)
                throw new Exception("Nie wczytano pliku ExtensionDisplayConfiguration.txt");
            if (!additionalEffects.ContainsKey(messageTypeString))
                throw new Exception(String.Format("Nie odnaleziono efektu w pliku konfiguracyjnym dla komunikatu {0}", command));

            var effect = additionalEffects[messageTypeString];
            var fullCommand = GetFullComand(effect, values);

            return fullCommand;
        }

        private static List<int> GetValuesFromCommand(string command)
        {
            //"DISP:11,1,0;"
            var valueInString = command.Replace("DISP:", "").Replace(";", "");
            var splittedValue = valueInString.Split(',').ToList();
            var values = splittedValue.Select(value => Convert.ToInt32(value)).ToList();
            return values;
        }

        private static MessageType GetMessageType(string command, IReadOnlyList<int> values)
        {
            var displayMode = Configuration.Instance.GetDisplayMode();

            MessageType messageType;

            if (displayMode == DisplayMode.OneNumber)
            {
                if (values[0] <= 9)
                    messageType = MessageType.J;
                else if (values[0] <= 99)
                    messageType = MessageType.D;
                else
                    throw new Exception(String.Format("Nie przewidziano efektu w programie dla komunikatu {0}", command));
                return messageType;
            }

            if (displayMode == DisplayMode.OneNumber)
            {
                if (values[0] <= 9 && values[1] <= 9)
                    messageType = MessageType.Jj;
                else if (values[0] <= 9 && values[1] <= 99)
                    messageType = MessageType.Jd;
                else if (values[0] <= 99 && values[1] <= 9)
                    messageType = MessageType.Dj;
                else if (values[0] <= 99 && values[1] <= 99)
                    messageType = MessageType.Dd;
                else
                    throw new Exception(String.Format("Nie przewidziano efektu w programie dla komunikatu {0}", command));
                return messageType;
            }

            throw new Exception(String.Format("Nie przewidziano efektu w programie dla komunikatu {0}", command));
        }

        private static string GetFullComand(string effect, IReadOnlyList<int> values)
        {
            effect = effect.Replace("#availableColor", values[0] > 0 ? "G" : "R");
            effect = effect.Replace("#notAvailableColor", values[1] > 0 ? "G" : "R");

            effect = effect.Replace("#availablePlaces", GetValueWithSpace(values[0]));
            effect = effect.Replace("#notAvailablePlaces", GetValueWithSpace(values[1]));
            return effect;
        }

        private static string GetValueWithSpace(int value)
        {
            var valueInString = value.ToString(CultureInfo.InvariantCulture);
            var length = valueInString.Length;
            for (var i = length; i < 10; i++)
                valueInString += " ";
            return valueInString;
        }
    }
}
