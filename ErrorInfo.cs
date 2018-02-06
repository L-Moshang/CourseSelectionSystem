using System;

namespace sc
{
	/// <summary>
	/// 错误信息类
	/// </summary>
	public class ErrorInfo
	{
        public const int ERR_DATABASE = 0;
        public const int ERR_NOSTUDENT = 1;
        public const int ERR_NOTEACHER = 2;
        public const int ERR_NOADMIN = 3;
        public const int ERR_KEYERROR = 4;
        public const int ERR_SCTIMEEARLY = 5;
        public const int ERR_SCTIMELATE = 6;
        public const int ERR_NOTLOGIN = 7;
        public const int ERR_NOTTEACHER = 8;
        public const int ERR_NOTADMIN = 9;

		public ErrorInfo()
		{
		}

        public static string Message(int errorCode)
        {
            switch(errorCode)
            {
                case    ERR_DATABASE :
                    return "数据库错误！";
                case    ERR_NOSTUDENT:
                    return "没有该学生！";
                case    ERR_NOTEACHER:
                    return "没有该老师！";
                case ERR_NOADMIN:
                    return "没有该系统管理员！";
                case    ERR_KEYERROR:
                    return "密码错误！";
                case    ERR_SCTIMEEARLY:
                    return "选课时间未到，不能选课！";
                case ERR_SCTIMELATE:
                    return "选课时间已过，不能选课！";
                case ERR_NOTLOGIN:
                    return "未登陆！，请先登陆！";
                case ERR_NOTTEACHER:
                    return "对不起，您不是老师，没有权限！";
                case ERR_NOTADMIN:
                    return "对不起，您不是系统管理员，没有权限！";
                default:
                    return  "";
            }
        }
	}
}
