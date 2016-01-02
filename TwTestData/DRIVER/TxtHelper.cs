using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwTestData.DRIVER
{
    public class TxtHelper
    {
        public static bool Save(string filePath, StringBuilder data, Encoding code)
        {
            // FileMode.CreateNew: 如果文件不存在，创建文件；如果文件已经存在，抛出异常 
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, code);
                sw.WriteLine(data.ToString());
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }


        public static StringBuilder Read(string filePath, Encoding code)
        {
            var sbuild = new StringBuilder();
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                StreamReader sr = new StreamReader(fs, code);
                using (fs)
                {
                    /*
                    CopyFrom:http://www.cnblogs.com/jx270/archive/2013/04/14/3020456.html 
                    */

                    while (!sr.EndOfStream)
                    {
                        sbuild.Append(sr.ReadLine());
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return sbuild;
        }
    }
}
