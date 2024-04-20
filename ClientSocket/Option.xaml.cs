using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ClientSocket
{
    /// <summary>
    /// Option.xaml 的交互逻辑
    /// </summary>
    public partial class Option : Window
    {
        public Option()
        {
            InitializeComponent();

        }

        private void HandleEvent(object sender, RoutedEventArgs e)
        {
            var target = int.Parse((sender as Button).CommandParameter.ToString());
            if (target == 1)
            {
                this.DialogResult = true;
                UpdateAppConfig("Num", Invet.Text);
                UpdateAppConfig("Wait", Wait.Text);
            }
            else this.DialogResult = false;
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

        private void Handle(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
