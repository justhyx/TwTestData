using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using System.Data.Entity;
using System.IO;

namespace TwTestData
{
    public class ExcelReader
    {
        public IExcelDataReader ReadExcel(string filePaht, string sheetName)
        {

            IExcelDataReader rd = new ExcelReader().ReadExcel(filePaht, sheetName);

            rd.IsFirstRowAsColumnNames = true;



        }
    }
}
