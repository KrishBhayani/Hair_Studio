using System;
namespace Hair_Studio.DAL
{
    public class DALHelper
    {
        #region Connection String
        public static string ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("ConnectionString");
        #endregion
    }
}

