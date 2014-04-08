using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilityClass
{
    /// <summary>
    /// 调用系统API 读写 ini 配置文件
    /// </summary>
    public class RWini
    {
        #region ========ini 读写========

        // 声明INI文件的写操作函数 WritePrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // 声明INI文件的读操作函数 GetPrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);

        public static void WriteIni(string section, string key, string value,string path)
        {
            // section=配置节，key=键名，value=键值，path=路径
            WritePrivateProfileString(section, key, value, path);
        }

        public static string ReadIni(string section, string key,string path)
        {
            // 每次从ini中读取多少字节
            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
            // section=配置节，key=键名，temp=上面，path=路径
            GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp.ToString();
        }

        // 为了分层，已停用（当对不同 ini 文件读写时，此方法过时）
        //public static void WriteIni(string section, string key, string value)
        //{
        //    // section=配置节，key=键名，value=键值，path=路径
        //    WritePrivateProfileString(section, key, value, FormBooks.path);
        //}

        // 为了分层，已停用（当对不同 ini 文件读写时，此方法过时）
        //public static string ReadIni(string section, string key)
        //{
        //    // 每次从ini中读取多少字节
        //    System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
        //    // section=配置节，key=键名，temp=上面，path=路径
        //    GetPrivateProfileString(section, key, "", temp, 255, FormBooks.path);
        //    return temp.ToString();
        //}
        #endregion
    }
}
