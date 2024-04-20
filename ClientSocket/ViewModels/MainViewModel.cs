using ClientSocket.Models;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private ObservableCollection<DeviceModel> _Devcie;
        public ObservableCollection<DeviceModel> Device
        {
            get { return _Devcie; }
            set { SetAndNotify(ref _Devcie, value); }
        }

        private string _Fix;

        public string Fix
        {
            get { return _Fix; }
            set
            {
                SetAndNotify(ref _Fix, value);
                UpdateAppConfig("Num", value);
            }
        }


        private void UpdateAppConfig(string newKey, string newValue)
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClientSocket.dll");
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            bool exist = false;
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == newKey)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
