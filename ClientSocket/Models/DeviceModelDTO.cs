using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket.Models
{
    public class DeviceModelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public double Width { get; set; }
        public bool IsBegin { get; set; }
        public bool IsAuto { get; set; }
        public int Count { get; set; }
        public double CycleTime { get; set; }
        public double TotalTime { get; set; }
        public int No {  get; set; }
        public string Colors {  get; set; }
        public bool IsSame {  get; set; }
    }
}
