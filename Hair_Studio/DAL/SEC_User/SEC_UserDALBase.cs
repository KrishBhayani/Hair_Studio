using System;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace Hair_Studio.DAL.SEC_User
{
	public class SEC_UserDALBase:DALHelper
	{
        #region Method : PR_User_SelectByUserNamePassword
        public DataTable PR_User_SelectByUserNamePassword(string UserName, string Password)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_User_SelectByUserNamePassword");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", DbType.String, UserName);
                sqlDatabase.AddInParameter(dbCommand, "@Password", DbType.String, Password);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch
            {
                return null;

            }
        }
        #endregion
    }
}

