using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataOffsets.Dto
{
    public class RootGatherModel
    {
        /// <summary>
        /// 运行信息
        /// </summary>
        public List<RunInfos> Runs { get; set; }
        /// <summary>
        /// 报警信息
        /// </summary>
        public List<AlarmInfos> Alarms { get; set; }
        /// <summary>
        /// 加工刀具信息
        /// </summary>
        public List<KnifeInfos> Cutters { get; set; }
        /// <summary>
        /// 基础信息
        /// </summary>
        public BasicInfos EqBase { get; set; }
    }

    public class KnifeInfos
    {
        /// <summary>
        /// 刀具码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 刀尖号
        /// </summary>
        [JsonPropertyName("PointNum")]
        public int Tips { get; set; }
        /// <summary>
        /// 加工刀具号
        /// </summary>
        [JsonPropertyName("EqNum")]
        public string CycleNo { get; set; }
        /// <summary>
        /// 子刀号
        /// </summary>
        [JsonPropertyName("ChildNum")]
        public int ChildNo { get; set; }
        /// <summary>
        /// 极限加工数量
        /// </summary>
        [JsonPropertyName("MaxCount")]
        public int Max { get; set; }
        /// <summary>
        /// 使用数量
        /// </summary>
        [JsonPropertyName("UsedCount")]
        public int UsedCount { get; set; }
        /// <summary>
        /// 可超极限比例(百分比)
        /// </summary>
        public int Maximum { get; set; }
    }

    public class AlarmInfos
    {
        /// <summary>
        /// 警告内容
        /// </summary>
        [JsonPropertyName("Content")]
        public string AlarmContent { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        [JsonPropertyName("Time")]
        public DateTime HappenTime { get; set; }
    }

    public class RunInfos
    {
        /// <summary>
        /// 刀号
        /// </summary>
        public string KnifeNo { get; set; }
        /// <summary>
        /// 主轴转速
        /// </summary>
        [JsonPropertyName("MainSpeed")]
        public double MainAxesSpeed { get; set; }
        /// <summary>
        /// 进给速度
        /// </summary>
        public double FeedSpeed { get; set; }
        /// <summary>
        /// 主轴倍率
        /// </summary>
        [JsonPropertyName("MainRate")]
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
        /// 机加关键时间点
        /// </summary>
        public double KeyTime { get; set; }
    }

    public class BasicInfos
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
        [JsonPropertyName("CurSeconds")]
        public double PowerON { get; set; }
        /// <summary>
        /// 开机时间
        /// </summary>
        public double CurHours { get; set; }
        /// <summary>
        /// 累计开机时间
        /// </summary>
        [JsonPropertyName("AllSeconds")]
        public double PowerONAlways { get; set; }
        /// <summary>
        /// 累计安装时间
        /// </summary>
        [JsonPropertyName("AllHours")]
        public double InstallTime { get; set; }
        /// <summary>
        /// 当前工件加工时间
        /// </summary>
        [JsonPropertyName("SingleTime")]
        public double CycleTime { get; set; }
        /// <summary>
        /// 工件数
        /// </summary>
        [JsonPropertyName("Count")]
        public int PartCount { get; set; }
        /// <summary>
        /// 总工件数
        /// </summary>
        [JsonPropertyName("AllCount")]
        public int TotalCount { get; set; }
    }
}
