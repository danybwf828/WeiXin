using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Form1.Public
{
    public class LogBB
    {
        public delegate void LogCallback(string strMsg);
        private LogCallback logCallback;

        private string strMessage = null;
        private string strPathName = null;
        private object sysObject = new object();
        Mutex mut = new Mutex();

        public LogBB(string strMsg, string strFilePathName, LogCallback logCallbackDelegate)
        {
            strMessage = strMsg;
            strPathName = strFilePathName;
            logCallback = logCallbackDelegate;
        }

        public void LogNoFile()
        {
            if (logCallback != null)
            {
                logCallback(strMessage);
            }
        }

        public void LogYesFile()
        {
            if (logCallback != null)
            {
                try
                {
                    lock (sysObject)
                    {
                        mut.WaitOne();
                        //FileInfo finfo = new FileInfo(strPathName);
                        //using (FileStream fs = finfo.OpenWrite())
                        //{
                        FileStream fs = new FileStream(strPathName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        using (StreamWriter w = new StreamWriter(fs, Encoding.Unicode))
                        {
                            w.AutoFlush = true;
                            w.BaseStream.Seek(0, SeekOrigin.End);
                            w.WriteLine(Convert.ToString(strMessage));
                            //w.Flush();
                            //w.Close();
                            //w.Dispose();// 释放对象使用的所有资源
                            //Thread.Sleep(20);
                            //w.Dispose(true);
                            //GC.SuppressFinalize(this);
                        }
                        fs.Close();
                        fs.Dispose();
                        //}
                        Thread.Sleep(0);// 释放CPU时间片
                        mut.ReleaseMutex();
                    }
                }
                //catch (AbandonedMutexException amex)
                //{
                //    strMessage += ",(AbandonedMutexException)写入文件出错，原因：" + amex.Message;
                //    mut.ReleaseMutex();
                //}
                catch (Exception ex)
                {
                    strMessage += ",(Exception)写入文件出错，原因：" + ex.Message;
                }
                logCallback(strMessage);
            }
        }
    }

}
