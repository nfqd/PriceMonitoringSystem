using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceMonitoringSystem
{
    class FileWrite
    {
        public void FileStreamWrite(string info, string filePath)
        {
            //string filePath = Directory.GetCurrentDirectory() + "\\" + Process.GetCurrentProcess().ProcessName + ".txt";
            if (File.Exists(filePath))
                File.Delete(filePath);

            FileStream fs = new FileStream(filePath, FileMode.Create);
            //获得字节数组


            byte[] data = System.Text.Encoding.Default.GetBytes(info);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

    }
}
