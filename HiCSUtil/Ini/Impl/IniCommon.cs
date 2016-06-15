using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace HiCSUtil.Ini.Impl
{
    static class IniCommon
    {
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <returns>返回的键值</returns>
        public static string ReadString(string section, string key, string file, string defValue = "") 
        { 
            if (!File.Exists(file))
            {
                return defValue;
            }

            StringBuilder temp = new StringBuilder(255);

            int i = GetPrivateProfileString(section, key, defValue, temp, 255, file); 
            return temp.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="file"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static int ReadInt(string section, string key, string file, int defValue = -1)
        {
            string val = ReadString(section, key, file);
            if (val == "")
            {
                return defValue;
            }

            try
            {
                return Convert.ToInt32(val);
            }
            catch(Exception ex)
            {
                ex.ToString();
                return defValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section">要读取的段落名</param>
        /// <param name="key">要读取的键</param>
        /// <param name="defVal">读取异常的情况下的缺省值</param>
        /// <param name="retVal">此参数类型不是string，而是Byte[]用于返回byte类型的section组或键值组。</param>
        /// <param name="size">值允许的大小</param>
        /// <param name="filePath">INI文件的完整路径和文件名</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath); 

             /// <summary>
        /// 
        /// </summary>
        /// <param name="section">要读取的段落名</param>
        /// <param name="key">要读取的键</param>
        /// <param name="defVal">读取异常的情况下的缺省值</param>
        /// <param name="retVal">此参数类型不是string，而是Byte[]用于返回byte类型的section组或键值组。</param>
        /// <param name="size">值允许的大小</param>
        /// <param name="filePath">INI文件的完整路径和文件名</param>
        /// <returns></returns>
       [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);
    }
}
