using System;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using Hair_Studio.Areas.Stylist.Models;
using Hair_Studio.Areas.Service.Models;

namespace Hair_Studio.DAL.Stylist
{
	public class StylistDALBase:DALHelper
	{
        #region Method : Stylist SelectAll
        public DataTable StylistSelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Stylist_SelectAll");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : Stylist Insert and Update
        public bool StylistSave(StylistModel stylistModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (stylistModel.StylistID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Stylist_Insert");
                    //sqlDatabase.AddInParameter(dbCommand, "@StylistID", DbType.String, stylistModel.StylistID);
                   
                    sqlDatabase.AddInParameter(dbCommand, "@ServiceID", DbType.Int32, stylistModel.ServiceID);
                    sqlDatabase.AddInParameter(dbCommand, "@StylistName", DbType.String, stylistModel.StylistName);
                    sqlDatabase.AddInParameter(dbCommand, "@Phone", DbType.String, stylistModel.Phone);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, stylistModel.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@ImageURL", DbType.String, stylistModel.ImageURL);

                    sqlDatabase.AddInParameter(dbCommand, "@Created", DbType.DateTime, DBNull.Value);
                    sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.DateTime, DBNull.Value);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Stylist_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@ServiceID", DbType.Int32, stylistModel.ServiceID);
                    sqlDatabase.AddInParameter(dbCommand, "@StylistID", DbType.String, stylistModel.StylistID);
                    sqlDatabase.AddInParameter(dbCommand, "@StylistName", DbType.String, stylistModel.StylistName);
                    sqlDatabase.AddInParameter(dbCommand, "@Phone", DbType.String, stylistModel.Phone);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, stylistModel.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@ImageURL", DbType.String, stylistModel.ImageURL);

                    sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.DateTime, DBNull.Value);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        #endregion

        #region Method : Stylist By ID
        public StylistModel StylistByID(int StylistID)
        {
            StylistModel stylistModel = new StylistModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Stylist_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@StylistID", DbType.Int32, StylistID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    stylistModel.StylistID = Convert.ToInt32(dataRow["StylistID"]);
                    stylistModel.ServiceID= Convert.ToInt32(dataRow["ServiceID"]);
                    stylistModel.StylistName = dataRow["StylistName"].ToString();
                    stylistModel.Phone = dataRow["Phone"].ToString();
                    stylistModel.Email = dataRow["Email"].ToString();
                    stylistModel.ImageURL = dataRow["ImageURL"].ToString();
                }
                return stylistModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : Stylist Delete
        public bool StylistDelete(int StylistID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Stylist_DeleteByPK");
                sqlDatabase.AddInParameter(dbCommand, "@StylistID", DbType.Int32, StylistID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion
    }
}

