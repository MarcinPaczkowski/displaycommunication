using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DisplayCommon.Models;

namespace DisplayCommon.Utils
{
    public class Configuration
    {
        readonly Dictionary<string, string> _configSqlParams;
        readonly Dictionary<string, string> _configAdditionalEffectsParams;
        private DisplayMode _displayMode;
        // ReSharper disable once InconsistentNaming
        static readonly Configuration _instance = new Configuration();

        static Configuration()
        {
        }

        private Configuration()
        {
            _configSqlParams = new Dictionary<string, string>();
            _configAdditionalEffectsParams = new Dictionary<string, string>();
        }

        public static Configuration Instance
        {
            get
            {
                return _instance;
            }
        }

        public void CreateConfiguration(string configFileName)
        {
            var vBody = new XElement("configuration");

            foreach (var item in _configSqlParams)
            {
                vBody.Add(new XElement("param", new XAttribute("name", item.Key), item.Value));
            }

            vBody.Save(configFileName);
        }

        public void LoadSqlConfiguration(string configFileName)
        {
            var conf = XDocument.Load(configFileName);
            foreach (var elem in conf.Descendants("configuration").Elements("param"))
                _configSqlParams.Add(elem.Attribute("name").Value, elem.Value);

            DbConnection.InitializeDb(GetEmptyDatabaseConfiguration());
        }

        public void LoadAdditionalEffectsConfiguration(string configFileName)
        {
            var lines = File.ReadAllLines(configFileName).ToList();
            SetDisplayMode(lines.First());

            foreach (var spliitedLine in lines.Skip(1).Select(line => line.Split('\t')))
                _configAdditionalEffectsParams.Add(spliitedLine[0], spliitedLine[1]);
        }

        private void SetDisplayMode(string line)
        {
            if (line.Equals("1"))
                _displayMode = DisplayMode.OneNumber;
            else if (line.Equals("2"))
                _displayMode = DisplayMode.TwoNumber;
            else if (line.Equals("3"))
                _displayMode = DisplayMode.ThreeNumber;
        }

        public DisplayMode GetDisplayMode()
        {
            return _displayMode;
        }

        public void SetValue(string key, string value)
        {
            if (_configSqlParams.ContainsKey(key))
                _configSqlParams[key] = value;
            else
                _configSqlParams.Add(key, value);
        }

        public string GetValue(string paramName)
        {
            if (_configSqlParams.ContainsKey(paramName))
                return _configSqlParams[paramName];
            throw new Exception(String.Format("{0} {1} {2}",
                "Brak parametru", paramName, "w pliku konfiguracyjnym"));
        }

        public Dictionary<string, string> GetAdditionalEffects()
        {
            return _configAdditionalEffectsParams;
        }

        public DatabaseConfiguration GetEmptyDatabaseConfiguration()
        {
            return new DatabaseConfiguration
            {
                UserName = GetValue("User"),
                Password = GetValue("Password"),
                Host = GetValue("Server"),
                Database = GetValue("Database"),
                Port = Convert.ToInt32(GetValue("Port")),
            };
        }
    }
}
