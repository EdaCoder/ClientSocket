using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientSocket.DTO
{
    public class BasicInfoModel
    {
        /// <summary>
        /// 程序号
        /// </summary>
        public string Program { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 基本类型
        /// </summary>
        public string CNCType { get; set; }
        /// <summary>
        /// 累计加工时间
        /// </summary>
        public double CutTotalTime { get; set; }
        /// <summary>
        /// 开机时间
        /// </summary>
        public double PowerON { get; set; }
        /// <summary>
        /// 开机时间
        /// </summary>
        public double CurHours { get; set; }
        /// <summary>
        /// 累计开机时间
        /// </summary>
        public double PowerONAlways { get; set; }
        /// <summary>
        /// 累计安装时间
        /// </summary>
        public double InstallTime { get; set; }
        /// <summary>
        /// 当前工件加工时间
        /// </summary>
        public double CycleTime { get; set; }
        /// <summary>
        /// 工件数
        /// </summary>
        public int PartCount { get; set; }
        /// <summary>
        /// 总工件数
        /// </summary>
        public int TotalCount { get; set; }
    }
}
