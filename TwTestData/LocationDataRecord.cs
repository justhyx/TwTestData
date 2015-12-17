using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwTestData
{
    public class LocationDataRecord
    {
        public int TestId { get; set; }

        public int ServerID { get; set; }
        public int DataType { get; set; }// 0：GPS 1：LBS AMAP 2：LBS MINIGPS
        public double Latitude { get; set; }
    }
}
