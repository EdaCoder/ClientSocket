using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket.DTO
{
    public class HeartInfoModel
    {
        /// <summary>
        /// 累计开机时间
        /// </summary>
        public double AllOpenSeconds { get; set; }
        /// <summary>
        /// 累计加工时间
        /// </summary>
        public double AllWorkSeconds { get; set; }
        /// <summary>
        /// 今日开机总时间
        /// </summary>
        public double TodayOpenSeconds { get; set; }
        /// <summary>
        /// 今日加工总时间
        /// </summary>
        public double TodayWorkSeconds { get; set; }
        /// <summary>
        /// 加工工件数
        /// </summary>
        public int CycleCount {  get; set; }
    }
}
