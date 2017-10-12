using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NingFan.Utility.DbHelper
{
    /// <summary>
    /// 提供sql语句debug测试
    /// </summary>
    public class SqlLogger
    {
        /// <summary>
        /// 是否输出日志时间
        /// </summary>
        public static bool logdate = false;
        /// <summary>
        /// 输出日志到sqllog.txt
        /// </summary>
        /// <param name="sql"></param>
        public static void Log(string sql)
        {
            FileInfo fi = new FileInfo("C:\\NF\\CS\\sqllog.txt");
            if (!fi.Exists) { fi.Create(); fi.Refresh(); }
            if (logdate)
            {
                sql = "("+DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + ")\r\n{\r\n" + sql+"\r\n}\r\n\r\n";
            }else
            {
                sql = "\r\n" + sql + "\r\n";
            }
            FileStream fs=fi.OpenWrite();
            fs.Seek(0, SeekOrigin.End);
            byte[] bytes = Encoding.UTF8.GetBytes(sql);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
        }
        /// <summary>
        /// 输出日志到sqllog.txt
        /// </summary>
        /// <param name="sqlList"></param>
        public static void Log(List<string> sqlList)
        {
            FileInfo fi = new FileInfo("C:\\NF\\CS\\sqllog.txt");
            if (!fi.Exists) { fi.Create(); fi.Refresh(); }
            string sql = string.Empty;
            if(logdate)
                sql = "(" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + ")\r\n{\r\n";
            foreach (string isql in sqlList)
            {
                sql += isql+";\r\n";
            }
            if (logdate)
                sql += "}\r\n\r\n";
            FileStream fs = fi.OpenWrite();
            fs.Seek(0, SeekOrigin.End);
            byte[] bytes = Encoding.UTF8.GetBytes(sql);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
        }
        /// <summary>
        /// 输出日志到sqllog.txt
        /// </summary>
        /// <param name="sqlList"></param>
        public static void Log(ArrayList sqlList)
        {
            Log(sqlList.Cast<string>().ToList());
        }

        /// <summary>
        /// 清空日志内容
        /// </summary>
        /// <param name="sql"></param>
        public static void ClearLog()
        {
            FileInfo fi = new FileInfo("C:\\NF\\CS\\sqllog.txt");
            if (!fi.Exists) { fi.Create(); fi.Refresh(); }
            FileStream fs=fi.Open(FileMode.Truncate);
            fs.Flush();
            fs.Close();
        }

        /// <summary>
        /// 输出单条日志到sqllog.txt,之前的日志会被清除
        /// </summary>
        /// <param name="sql"></param>
        public static void LogOnce(string sql)
        {
            ClearLog();
            Log(sql);
        }
        /// <summary>
        /// 输出单条日志到sqllog.txt,之前的日志会被清除
        /// </summary>
        /// <param name="sqlList"></param>
        public static void LogOnce(List<string> sqlList)
        {
            ClearLog();
            Log(sqlList);
        }
        /// <summary>
        /// 输出单条日志到sqllog.txt,之前的日志会被清除
        /// </summary>
        /// <param name="sqlList"></param>
        public static void LogOnce(ArrayList sqlList)
        {
            ClearLog();
            Log(sqlList.Cast<string>().ToList());
        }

    }
}
