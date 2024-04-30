using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket.DTO
{
    public class CheckInfoModel
    {
        /// <summary>
        /// 总高标准
        /// </summary>
        public double HeightStandard { get; set; }
        /// <summary>
        /// 孔径标准
        /// </summary>
        public double ApertureStandard { get; set; }
        /// <summary>
        /// 实际总高
        /// </summary>
        public double RealityHeight { get; set; }
        /// <summary>
        /// 实际孔径
        /// </summary>
        public double RealityAperture { get; set; }
        /// <summary>
        /// 检测结果 1-合格，2-不良
        /// </summary>
        public int CheckRes { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count {  get; set; }
    }
}
