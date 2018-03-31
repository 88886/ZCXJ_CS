using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ZCXJ_CS.Utilities
{
    /// <summary>
    /// 助理类
    /// </summary>
	public class Utils
    {
        /// <summary>
        /// 将时间转化成中文常规格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string DateTimeToZh(DateTime dt)
        {
            string temp = string.Empty;
            if (dt > DateTime.MinValue)
            {
                DateTime now = DateTime.Now;
                int dayofweek = (int)now.DayOfWeek;
                int days = (now - dt).Days;
                if (days < (dayofweek + 7))
                {
                    switch (days)
                    {
                        case 0:
                            temp = "今天";
                            break;
                        case 1:
                            temp = "昨天";
                            break;
                        case 2:
                            temp = "前天";
                            break;
                        default:
                            if (days >= dayofweek)
                                temp = "上";
                            switch ((int)dt.DayOfWeek)
                            {
                                case 0:
                                    temp += "周日";
                                    break;
                                case 1:
                                    temp += "周一";
                                    break;
                                case 2:
                                    temp += "周二";
                                    break;
                                case 3:
                                    temp += "周三";
                                    break;
                                case 4:
                                    temp += "周四";
                                    break;
                                case 5:
                                    temp += "周五";
                                    break;
                                case 6:
                                    temp += "周六";
                                    break;

                            }
                            break;
                    }
                    temp += dt.ToString(" HH:mm"); 
                }
                else
                {
                    temp = dt.ToString("dd号 HH:mm");
                }
            }
            return temp;
        }
    }
}
