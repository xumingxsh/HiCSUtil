using System;
using System.IO;

namespace HiCSUtil
{
    /// <summary>
    /// 判断文件是否在上次访问后被修改
    /// XuminRong 2016-06-15
    /// </summary>
    public sealed class FileMonitor
    {
        DateTime dt = DateTime.Now.AddYears(-1);

        public bool SetFile(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            file = path;
            dt = File.GetLastWriteTime(file);
            return true;
        }

        public bool IsChanged
        {
            get
            {
                if (!File.Exists(file))
                {
                    return false;
                }
                if (File.GetLastWriteTime(file) > dt)
                {
                    dt = File.GetLastWriteTime(file);
                    return true;
                }
                return false;
            }
        }

        string file;
    }
}
