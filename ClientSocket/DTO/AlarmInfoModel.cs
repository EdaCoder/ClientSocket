using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientSocket.DTO
{
    public class AlarmInfoModel
    {
        /// <summary>
        /// 警告内容
        /// </summary>
        public string AlarmContent { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime HappenTime { get; set; }
    }

}