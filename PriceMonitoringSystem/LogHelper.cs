using System;
using System.Collections.Generic;

using System.Text;


namespace PriceMonitoringSystem
{
    class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        //public static void WriteLog(string info, Exception se)
        //{
        //    if (logerror.IsErrorEnabled)
        //    {
        //        logerror.Error(info, se);
        //    }
        //}
    }
}
