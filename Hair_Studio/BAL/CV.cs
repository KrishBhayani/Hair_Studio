namespace Hair_Studio.BAL
{
    public class CV
    {
        private static IHttpContextAccessor _HttpContextAccessor;
        static CV()
        {
            _HttpContextAccessor = new HttpContextAccessor();
        }

        public static int? UserID()
        {
            return Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetString("UserID"));
        }

        public static string UserName()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("UserName");
        }

        public static bool IsAdmin()
        {
            bool x = Convert.ToBoolean(_HttpContextAccessor.HttpContext.Session.GetString("IsAdmin"));
            return x;
        }
    }
}

