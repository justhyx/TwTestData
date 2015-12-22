﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;

namespace TwTestData
{
    /// <summary>
    /// Polo 定位数据基础类
    /// </summary>
    public class LocationDataRecord
    {
        public int TestId { get; set; }

        public int ServerID { get; set; }
        public LocationDateSource DataType { get; set; }// 0：GPS 1：LBS AMAP 2：LBS MINIGPS

        /// <summary>
        /// 纬度 (北正南负)
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 经度（东正西负）
        /// </summary>
        public double Longitude { get; set; }
        public DateTime LocationTime { get; set; }
        public string LocationAddress { get; set; }
        public string IMEI { get; set; }

        private static int testid = 0;
        public static LocationDateSource TableMark = LocationDateSource.GPS;
        public static LocationDataRecord Factory(IExcelDataReader rd)
        {
            if (Enum.IsDefined(typeof(LocationDateSource), TableMark)) throw new ArrayTypeMismatchException("Laction Data Type Error");

            var record = new LocationDataRecord();

            record.TestId = testid++;
            record.ServerID = rd.GetInt32(1); //id 
            record.DataType = TableMark;
            record.Latitude = rd.GetDouble(2); //纬度        
            record.Longitude = rd.GetDouble(3); //经度
            record.IMEI = rd.GetString(4); //imei
            record.LocationAddress = rd.GetString(5); //address
            record.LocationTime = rd.GetDateTime(6); //location_time
            return record;
        }

    }

    public enum LocationDateSource
    {
        GPS = 0, AMAP = 1, MINIGPS = 2
    }
}