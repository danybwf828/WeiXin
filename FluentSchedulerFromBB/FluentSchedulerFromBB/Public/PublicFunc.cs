using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Form1.Public
{
    public class PublicFunc
    {
        public PublicFunc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 常量与变量

        #region 常量
        const string iniFile = "..\\..\\WConfig\\SysConfig.ini";

        #endregion

        #endregion

        #region 读取的配置（从Sys.ini中读取）  zcy
        [DllImport("kernel32")]
        public static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        /// <summary>
        /// 从INI文件中获取值

        /// </summary>
        /// <param name="top"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string ReadINI(string top, string keys)//对ini文件进行读操作的函数
        {
            StringBuilder temp = new StringBuilder(255);
            long i = GetPrivateProfileString(top, keys, "", temp, 255, iniFile);
            return temp.ToString();
        }

        /// <summary>
        /// 对INI文件进行写入，扩展，增加路径
        /// </summary>
        /// <param name="top">节点</param>
        /// <param name="keys">关键字</param>
        /// <param name="writeValue">值</param>
        /// <param name="strFilepath">路径</param>
        public static void WriteINI(string top, string keys, string writeValue)
        {
            WritePrivateProfileString(top, keys, writeValue, iniFile);
        }

        #endregion
    }
}
