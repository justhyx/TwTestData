using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwTestData.ALGORITHM
{
    /// <summary>
    /// 固定点观察值
    /// </summary>
    public class ObservedValueOfFixed
    {

        /// <summary>
        /// 观察开始时间
        /// </summary>
        public DateTime Begin { get; set; }
        /// <summary>
        /// 观察结束时间
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// 纬度 (北正南负)
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 经度（东正西负）
        /// </summary>
        public double Longitude { get; set; }

        public string Address { get; set; }

        public string[] TestIMEIGroup { get; set; }
    }
}
