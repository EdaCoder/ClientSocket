using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket.Models
{
    public class DeviceModel : BaseDevice
    {
        private double _Width;
        public double Width
        {
            get { return _Width; }
            set { SetAndNotify(ref _Width, value); }
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
        private bool _IsSame;
        public bool IsSame
        {
            get { return _IsSame; }
            set { SetAndNotify(ref _IsSame, value); }
        }
        private int _TodayCount;
        public int TodayCount
        {
            get { return _TodayCount; }
            set { SetAndNotify(ref _TodayCount, value); }
        } 
        private int _TodayCountLimit;
        public int TodayCountLimit
        {
            get { return _TodayCountLimit; }
            set { SetAndNotify(ref _TodayCountLimit, value); }
        }
    }
}
