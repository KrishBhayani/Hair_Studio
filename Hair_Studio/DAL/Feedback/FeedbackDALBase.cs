using System;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using Hair_Studio.Areas.Feedback.Models;

namespace Hair_Studio.DAL.Feedback
{
    public class FeedbackDALBase : DALHelper
    {
        #region Method : Feedback SelectAll
        public DataTable FeedbackSelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Feedback_SelectAll");
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

        #region Method : Feedback Insert and Update
        public bool FeedbackSave(FeedbackModel feedbackModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (feedbackModel.FeedbackID == 0)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Feedback_Insert");

                    sqlDatabase.AddInParameter(dbCommand, "@FirstName", DbType.String, feedbackModel.FirstName);
                    sqlDatabase.AddInParameter(dbCommand, "@LastName", DbType.String, feedbackModel.LastName);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, feedbackModel.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@Phone", DbType.String, feedbackModel.Phone);
                    sqlDatabase.AddInParameter(dbCommand, "@Rating", DbType.Int64, Convert.ToInt64(feedbackModel.Rating));
                    sqlDatabase.AddInParameter(dbCommand, "@Comments", DbType.String, feedbackModel.Comments);
             
                    //sqlDatabase.AddInParameter(dbCommand, "@Created", DbType.DateTime, DBNull.Value);
                    //sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.DateTime, DBNull.Value);

                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {

                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Feedback_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@FeedbackID", DbType.Int64, Convert.ToInt64(feedbackModel.FeedbackID));
                    sqlDatabase.AddInParameter(dbCommand, "@FirstName", DbType.String, feedbackModel.FirstName);
                    sqlDatabase.AddInParameter(dbCommand, "@LastName", DbType.String, feedbackModel.LastName);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, feedbackModel.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@Phone", DbType.String, feedbackModel.Phone);
                    sqlDatabase.AddInParameter(dbCommand, "@Rating", DbType.Int64, Convert.ToInt64(feedbackModel.Rating));
                    sqlDatabase.AddInParameter(dbCommand, "@Comments", DbType.String, feedbackModel.Comments);

                    sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.DateTime, DBNull.Value);

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

        #region Method : Feedback By ID
        public FeedbackModel FeedbackByID(int FeedbackID)
        {
            FeedbackModel feedbackModel = new FeedbackModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Feedback_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@FeedbackID", DbType.Int32, FeedbackID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    feedbackModel.FeedbackID = Convert.ToInt32(dataRow["FeedbackID"]);
                    feedbackModel.FirstName = dataRow["FirstName"].ToString();
                    feedbackModel.LastName = dataRow["LastName"].ToString();
                    feedbackModel.Email = dataRow["Email"].ToString();
                    feedbackModel.Phone = dataRow["Phone"].ToString();
                    feedbackModel.Rating = Convert.ToInt32(dataRow["Rating"]);
                    feedbackModel.Comments = dataRow["Comments"].ToString();
                }
                return feedbackModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : Feedback Delete
        public bool FeedbackDelete(int FeedbackID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Feedback_DeleteByPK");
                sqlDatabase.AddInParameter(dbCommand, "@FeedbackID", DbType.Int32, FeedbackID);
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

