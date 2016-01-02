using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using TwTestData.ALGORITHM;
using Excel;

namespace TwTestData
{
    public class FileReader
    {
        private static List<LocationDataRecord> Read(IDataReader rd, LocationDateSource datatype)
        {
            var Records = new List<LocationDataRecord>();
            LocationDataRecord.TableMark = datatype;
            while (rd.Read())
            {
                //excelReader.GetInt32(0);
                var d = LocationDataRecord.Factory(rd);
                if (d.ServerID > 0)
                {
                    Records.Add(d);
                }
            }
            return Records;
        }
        /// <summary>
        /// 将Excel之类的文件加载到内存
        /// </summary>
        /// <param name="filePath">文件地址</param>
        /// <param name="filetype">文件类型，目前只支持 xls 和 xlsx</param>
        /// <param name="datatype">定位数据是 GPS 、Amap LBS 、miniGPS LBS</param>
        /// <returns>回传一组定位数据</returns>
        public static List<LocationDataRecord> ReadXLSX(string filePath, LocationDateSource datatype)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            try
            {
                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader.IsFirstRowAsColumnNames = true;
                excelReader.Read();
                return Read(excelReader, datatype);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                excelReader.Close();
                stream.Close();
            }
        }
        public static List<LocationDataRecord> ReadXLS(string filePath, LocationDateSource datatype)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            try
            {
                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader.IsFirstRowAsColumnNames = true;
                excelReader.Read();
                return Read(excelReader, datatype);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                excelReader.Close();
                stream.Close();
            }
        }

  

        internal static List<ObservedValueOfFixed> ReadXLS(string f)
        {
            FileStream stream = File.Open(f, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            List<ObservedValueOfFixed> result = null;
            using (stream)
            {
                try
                {
                    excelReader.IsFirstRowAsColumnNames = true;
                    if (excelReader.Read())
                    {
                        result = Read(excelReader);
                    }
                    if (result == null) throw new Exception("Data File is Null!");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    excelReader.Close();
                    stream.Close();
                }
                return result;
            }
        }


        internal static List<ObservedValueOfFixed> ReadXLSX(string f)
        {
            FileStream stream = File.Open(f, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            List<ObservedValueOfFixed> result = null;
            using (stream)
            {
                try
                {
                    excelReader.IsFirstRowAsColumnNames = true;
                    if (excelReader.Read())
                    {
                        result = Read(excelReader);
                    }
                    if (result == null) throw new Exception("Data File is Null!");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);//   throw;                  
                }
                finally
                {
                    excelReader.Close();
                    stream.Close();
                }
                return result;
            }
        }

        private static List<ObservedValueOfFixed> Read(IExcelDataReader excelReader)
        {
            var Records = new List<ObservedValueOfFixed>();
            var FieldCount = excelReader.FieldCount;
            try
            {
                while (excelReader.Read())
                {
                    //excelReader.GetInt32(0);
                    Records.Add(new ObservedValueOfFixed()
                    {
                        Begin = excelReader.GetDateTime(0),
                        End = excelReader.GetDateTime(1),
                        Latitude = excelReader.GetDouble(2),
                        Longitude = excelReader.GetDouble(3),
                        Address = excelReader.GetString(4),
                        TestIMEIGroup = excelReader.GetString(5).Split(' '),
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Records;
        }
    }
}
