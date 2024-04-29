using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOffsets.Dto
{
    public class AutoDto
    {
        /// <summary>
        /// 生产线id
        /// </summary>
        public string ProLineId { get; set; }
        /// <summary>
        /// 生产线编号
        /// </summary>
        public string ProLineCode { get; set; }
        /// <summary>
        /// 生产线名称
        /// </summary>
        public string ProLineName { get; set; }
        /// <summary>
        /// 生产线对应产品
        /// </summary>
        public List<ProductLists> ProductList { get; set; }
        /// <summary>
        /// 用户生产线工序流程权限
        /// </summary>
        public List<ProcessLists> ProcessList { get; set; }
    }

    public class ProductLists
    {
        /// <summary>
        /// 产品id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
    }
    public class ProcessLists
    {
        /// <summary>
        /// 工序流程id
        /// </summary>
        public string ProcessId { get; set; }
        /// <summary>
        /// 工序流程编号
        /// </summary>
        public string ProcessCode { get; set; }
        /// <summary>
        /// 工序流程名称
        /// </summary>
        public string ProcessName { get; set; }
    }
}
