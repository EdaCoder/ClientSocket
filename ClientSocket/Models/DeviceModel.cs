using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket.Models
{
    public class DeviceModel : PropertyChangedBase
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { SetAndNotify(ref _id, value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetAndNotify(ref _name, value); }
        }
        private string _ip;
        public string Ip
        {
            get { return _ip; }
            set { SetAndNotify(ref _ip, value); }
        }
        private double _Width;
        public double Width
        {
            get { return _Width; }
            set { SetAndNotify(ref _Width, value); }
        }
        private bool _IsBegin;
        public bool IsBegin
        {
            get { return _IsBegin; }
            set { SetAndNotify(ref _IsBegin, value); }
        }
        private bool _IsAuto;
        public bool IsAuto
        {
            get { return _IsAuto; }
            set { SetAndNotify(ref _IsAuto, value); }
        }
        private int _Count;
        public int Count
        {
            get { return _Count; }
            set { SetAndNotify(ref _Count, value); }
        }
        private double _CycleTime;
        public double CycleTime
        {
            get { return _CycleTime; }
            set { SetAndNotify(ref _CycleTime, value); }
        }
        private double _TotalTime;
        public double TotalTime
        {
            get { return _TotalTime; }
            set { SetAndNotify(ref _TotalTime, value); }
        }
    }
}
