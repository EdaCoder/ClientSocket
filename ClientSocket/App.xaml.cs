using ClientSocket.ViewModels;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using XExten.Advance.IocFramework;

namespace ClientSocket
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IocDependency.Register(typeof(MainViewModel));
            base.OnStartup(e);
            WebHost.StartWeb();
        }
    }

}
