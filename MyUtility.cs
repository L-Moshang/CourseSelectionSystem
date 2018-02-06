using System;
using System.IO;
using System.Text;
using System.Web.Security;
using System.Configuration;

namespace sc
{
	/// <summary>
	/// 工具类
	/// </summary>
	public class MyUtility
	{
		public MyUtility()
		{
		}

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">被加密字符串</param>
        /// <returns>加密后字符串</returns>
        public static string MD5(string str)
        {
            string result = "";
            result = FormsAuthentication.HashPasswordForStoringInConfigFile(str,"MD5");
            return result;
        }

        /// <summary>
        /// HTML字符串编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {			
            str = str.Replace("&","&amp;");
            str = str.Replace("'","''");
            str = str.Replace("\"","&quot;");
            str = str.Replace(" ","&nbsp;");
            str = str.Replace("<","&lt;");
            str = str.Replace(">","&gt;");
            str = str.Replace("\n","<br>");
            return str;
        }

        /// <summary>
        /// HTML字符串解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decode(string str)
        {			
            str = str.Replace("<br>","\n");
            str = str.Replace("&gt;",">");
            str = str.Replace("&lt;","<");
            str = str.Replace("&nbsp;"," ");
            str = str.Replace("&quot;","\"");
            return str;
        }

        /// <summary>
        /// Alert显示一个字符串
        /// </summary>
        /// <param name="s">需要显示的字符串</param>
        /// <returns>为了Alert出字符串需要的html字符串</returns>
        public static string Alert(string s)
        {
            return "<script language=\"javascript\">alert(\""+s+"\");</script>";
        }

        /// <summary>
        /// 后退到第i个页面
        /// </summary>
        /// <param name="i"></param>
        /// <returns>为了后退到第i个页面需要的html字符串</returns>
        public static string Back(int i)
        {
            return "<script language=\"javascript\">location.href=\"javascript:history.go("+i+");\";</script>";
        }
        /// <summary>
        /// 检查当前时间是否在选课时间内
        /// </summary>
        /// <returns>
        /// -1:尚未到选课时间
        /// 0: 当前时间可以选课
        /// 1: 选课时间已过
        /// </returns>
        public static int CheckTime()
        {
            StreamReader sr = new StreamReader(ConfigurationSettings.AppSettings["time.txt"]);
            string strStart = sr.ReadLine();
            string strEnd = sr.ReadLine();
            sr.Close();
            DateTime dtStart = DateTime.Parse(strStart);
            DateTime dtEnd = DateTime.Parse(strEnd);
            DateTime dtNow = DateTime.Now;
            if ( dtNow > dtEnd )
                return 1;
            if ( dtNow < dtStart )
                return -1;
            return 0;
        }

        
        public static string GetWeekDayString(int i)
        {
            switch(i)
            {
                case 1:
                    return "星期一";
                case 2:
                    return "星期二";
                case 3:
                    return "星期三";
                case 4:
                    return "星期四";
                case 5:
                    return "星期五";
                case 6:
                    return "星期六";
                case 7:
                    return "星期天";
                default:
                    return "";
            }
        }

        public static string GetTimeString(int i)
        {
            switch(i)
            {
                case 1:
                    return "第1-2节课";
                case 2:
                    return "第3-4节课";
                case 3:
                    return "第5-6节课";
                case 4:
                    return "第7-8节课";
                case 5:
                    return "第9-10节课";
                default:
                    return "";
            }
        }
		
        public static string GetTimeString(string s)
        {
            string r="";
            r += GetWeekDayString(s[0]-'0');
            r += GetTimeString(s[1]-'0');
            return r;
        }
	}
}
