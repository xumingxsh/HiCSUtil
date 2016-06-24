using System;
using System.IO;

using HiCSUtil.Ini.Impl;

namespace HiCSUtil
{
    /// <summary>
    /// 读取Ini文件
    /// 注: C#的appconfig配置文件比较复杂,而且修改后,要同时修改setting文件才可以产生作用
    ///     这一点是比较烦人的,C++中常用的Ini文件则简洁的多
    ///  XuminRong 2016-06-15
    /// </summary>
    public sealed class CommonIni
    {
        public bool Init(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            file = path;
            return true;
        }

        public string ReadString(string section, string key, string defValue = "")
        {
            return IniCommon.ReadString(section, key, file, defValue);
        }

        public static int ReadInt(string section, string key, string file, int defValue = -1)
        {
            return IniCommon.ReadInt(section, key, file, defValue);
        }


        public static string ReadString(string section, string key, string file, string defValue = "")
        {
            return IniCommon.ReadString(section, key, file, defValue);
        }

        public int ReadInt(string section, string key, int defValue = -1)
        {
            return IniCommon.ReadInt(section, key, file, defValue);
        }
        public static bool Write(string section, string key, string val, string file)
        {
            return IniCommon.Write(section, key, val, file);
        }

        public bool Write(string section, string key, string val)
        {
            return Write(section, key, val, file);
        }

        string file;
    }
}
