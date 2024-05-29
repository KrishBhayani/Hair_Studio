using System;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using Hair_Studio.Areas.FAQs.Models;
using Hair_Studio.Areas.Stylist.Models;

namespace Hair_Studio.DAL.FAQs
{
	public class FAQsDALBase:DALHelper
	{
        #region Method : FAQs SelectAll
        public DataTable FAQsSelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FAQs_SelectAll");
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

        #region Method : FAQs Insert and Update
        public bool FAQsSave(FAQsModel fAQsModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (fAQsModel.FAQID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FAQs_Insert");

                    sqlDatabase.AddInParameter(dbCommand, "@Question", DbType.String, fAQsModel.Question);
                    sqlDatabase.AddInParameter(dbCommand, "@Answer", DbType.String, fAQsModel.Answer);
                   
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {

                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FAQs_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@FAQID", DbType.Int32, fAQsModel.FAQID);
                    sqlDatabase.AddInParameter(dbCommand, "@Question", DbType.String, fAQsModel.Question);
                    sqlDatabase.AddInParameter(dbCommand, "@Answer", DbType.String, fAQsModel.Answer);

                    sqlDatabase.ExecuteNonQuery(dbCommand);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }
        #endregion

        #region Method : FAQs By ID
        public FAQsModel FAQsByID(int FAQID)
        {
            FAQsModel fAQsModel = new FAQsModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FAQs_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@FAQID", DbType.Int32, FAQID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    fAQsModel.FAQID = Convert.ToInt32(dataRow["FAQID"]);
                    fAQsModel.Question = dataRow["Question"].ToString();
                    fAQsModel.Answer = dataRow["Answer"].ToString();
                }
                return fAQsModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : FAQs Delete
        public bool FAQsDelete(int FAQID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FAQs_DeleteByPK");
                sqlDatabase.AddInParameter(dbCommand, "@FAQID", DbType.Int32, FAQID);
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

