using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

namespace Lesson2
{
    public class ConfigManagment
    {
        public ConfigManagment()
        {

        }

        public string ReadSetting(string key)
        {
            string setting = null;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                setting = appSettings[key];

            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return setting;
        }

        public void AddUpdateAppSettings(object key, object value)
        {
            try
            {
                var _key = key.ToString();

                var _value = value.ToString();

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var settings = configFile.AppSettings.Settings;

                if (settings[_key] == null)
                {
                    settings.Add(_key, _value);
                }
                else
                {
                    settings[_key].Value = _value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
            
        public ICollection<KeyValuePair<string, string>> ReadAllSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                foreach(var p in appSettings.AllKeys)
                {
                    settings.Add(p, appSettings[p]);
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return settings;
        }
    }
}
