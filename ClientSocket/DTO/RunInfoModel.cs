using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientSocket.DTO
{
    public class RunInfoModel
    {
        /// <summary>
        /// 刀号
        /// </summary>
        public int KnifeNo { get; set; } = 0;
        /// <summary>
        /// 主轴转速
        /// </summary>

        public double MainAxesSpeed { get; set; }
        /// <summary>
        /// 进给速度
        /// </summary>
        public double FeedSpeed { get; set; }
        /// <summary>
        /// 主轴倍率
        /// </summary>

        public double MainAxesRate { get; set; }
        /// <summary>
        /// 进给倍率
        /// </summary>
        public double FeedRate { get; set; }
        /// <summary>
        /// X轴负载
        /// </summary>
        public double X { get; set; } = 0;
        /// <summary>
        /// C轴负载
        /// </summary>
        public double C { get; set; } = 0;
        /// <summary>
        /// Z轴负载/主轴负载
        /// </summary>
        public double Z { get; set; } = 0;
        /// <summary>
        /// Y轴负载
        /// </summary>
        public double Y { get; set; } = 0;
        /// <summary>
        /// 电流
        /// </summary>
        public double Current { get; set; }
        /// <summary>
        /// 耗电量
        /// </summary>
        public double PowerCon { get; set; }
        /// <summary>
        /// 关键时间
        /// </summary>
        public double KeyTime { get; set; }
    }
}
