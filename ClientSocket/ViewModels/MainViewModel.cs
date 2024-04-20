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
    }
}
