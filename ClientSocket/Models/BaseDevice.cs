﻿using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClientSocket.Models
{
    public class BaseDevice: PropertyChangedBase
    {

        private int _Invet;
        public int Invet
        {
            get { return _Invet; }
            set { SetAndNotify(ref _Invet, value); }
        }

        private bool _IsAuto;
        public bool IsAuto
        {
            get { return _IsAuto; }
            set { SetAndNotify(ref _IsAuto, value); }
        }
        private bool _IsBegin;
        public bool IsBegin
        {
            get { return _IsBegin; }
            set { SetAndNotify(ref _IsBegin, value); }
        }
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
        private int _No;
        public int No
        {
            get { return _No; }
            set { SetAndNotify(ref _No, value); }
        }
        private Brush _Color;
        public Brush Color
        {
            get { return _Color; }
            set { SetAndNotify(ref _Color, value); }
        }
    }
}
