using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket.Models
{
    public class CheckModelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public bool IsBegin { get; set; }
        public bool IsAuto { get; set; }
    }
}
