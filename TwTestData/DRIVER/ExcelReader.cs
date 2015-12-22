using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using System.Data.Entity;
using System.IO;
using System.Data;

namespace TwTestData
{
    public class ExcelReader
    {

        /// <summary>
        /// 将Excel之类的文件加载到内存
        /// </summary>
        /// <param name="filePath">文件地址</param>
        /// <param name="filetype">文件类型，目前只支持 xls 和 xlsx</param>
        /// <param name="datatype">定位数据是 GPS 、Amap LBS 、miniGPS LBS</param>
        /// <returns>回传一组定位数据</returns>
        public static List<LocationDataRecord> Read(string filePath, int filetype, LocationDateSource datatype)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;
            var Records = new List<LocationDataRecord>();
            switch (filetype)
            {
                case 1:
                    //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    break;
                //...

                //...
                //3. DataSet - The result of each spreadsheet will be created in the result.Tables
                //DataSet result = excelReader.AsDataSet();
                //...
                //4. DataSet - Create column names from first row
                //DataSet result = excelReader.AsDataSet();
                default:
                    //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    break;
            }

            excelReader.IsFirstRowAsColumnNames = true;
            LocationDataRecord.TableMark = datatype;

            //5. Data Reader methods
            while (excelReader.Read())
            {
                //excelReader.GetInt32(0);
                Records.Add(LocationDataRecord.Factory(excelReader));
            }

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
            LocationDataRecord.TableMark = LocationDateSource.GPS;
            return Records;
        }
    }
}
