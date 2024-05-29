using System;
using Hair_Studio.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using Hair_Studio.Areas.Appointment.Models;

namespace Hair_Studio.DAL.Appointment
{
	public class AppointmentDALBase:DALHelper
	{
        #region Method : Appointment SelectAll (Active)
        public DataTable AppointmentSelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Appointment_SelectAll");
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

        //#region Method : Appointment SelectAll (In Active)
        //public DataTable AppointmentDeletedSelectAll()
        //{
        //    try
        //    {
        //        SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
        //        DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Product_Deleted");
        //        DataTable dataTable = new DataTable();
        //        using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
        //        {
        //            dataTable.Load(dataReader);
        //        }
        //        return dataTable;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //#endregion

        #region Method : Appointment By ID
        public DataTable AppointmentByID(int AppointmentID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Appointment_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@AppointmentID", DbType.Int32, AppointmentID);
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

        #region Method : Appointment Insert & Update
        public bool AppointmentSave(AppointmentModel appointmentModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (appointmentModel.AppointmentID == 0)
                {
                    
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Appointment_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@ServiceID", DbType.Int32, appointmentModel.ServiceID);
                    sqlDatabase.AddInParameter(dbCommand, "@AppointmentDate", DbType.DateTime, appointmentModel.AppointmentDate);
                    sqlDatabase.AddInParameter(dbCommand, "@AppointmentTime", DbType.DateTime, appointmentModel.AppointmentTime);
                    sqlDatabase.AddInParameter(dbCommand, "@Name", DbType.String, appointmentModel.Name);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, appointmentModel.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@Phone", DbType.String, appointmentModel.Phone);
                    
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                { 
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Appointment_UpdateByPK");
                    sqlDatabase.AddInParameter(dbCommand, "@AppointmentID", DbType.Int32, appointmentModel.AppointmentID);
                    sqlDatabase.AddInParameter(dbCommand, "@ServiceID", DbType.Int32, appointmentModel.ServiceID);
                    sqlDatabase.AddInParameter(dbCommand, "@AppointmentDate", DbType.DateTime, appointmentModel.AppointmentDate);
                    sqlDatabase.AddInParameter(dbCommand, "@AppointmentTime", DbType.DateTime, appointmentModel.AppointmentTime);
                    sqlDatabase.AddInParameter(dbCommand, "@Name", DbType.String, appointmentModel.Name);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, appointmentModel.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@Phone", DbType.String, appointmentModel.Phone);
                    
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        //#region Method : Appointment By ID
        //public AppointmentModel ProductByID(int ProductID)
        //{
        //    ProductModel productModel = new ProductModel();
        //    try
        //    {
        //        SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
        //        DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Product_SelectByID");
        //        sqlDatabase.AddInParameter(dbCommand, "@ProductID", DbType.Int32, ProductID);
        //        DataTable dataTable = new DataTable();
        //        using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
        //        {
        //            dataTable.Load(dataReader);
        //        }
        //        foreach (DataRow dataRow in dataTable.Rows)
        //        {
        //            productModel.ProductID = Convert.ToInt32(dataRow["ProductID"]);
        //            productModel.ProductName = dataRow["ProductName"].ToString();
        //            productModel.Discription = dataRow["Discription"].ToString();
        //            productModel.Price = Convert.ToDouble(dataRow["Price"]);
        //            productModel.Code = dataRow["Code"].ToString();
        //            productModel.DisplayImage = dataRow["DisplayImage"].ToString();
        //            productModel.CategoryID = Convert.ToInt32(dataRow["CategoryID"]);
        //            productModel.isActive = Convert.ToBoolean(dataRow["isActive"]);
        //            productModel.Discount = Convert.ToInt32(dataRow["Discount"].ToString());
        //            productModel.Rating = Convert.ToInt32(dataRow["Rating"].ToString());
        //            productModel.Created = Convert.ToDateTime(dataRow["Created"]);
        //            productModel.Modified = Convert.ToDateTime(dataRow["Modified"]);
        //        }
        //        return productModel;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //#endregion

        #region Method : Appointment Delete
        public bool AppointmentDelete(int AppointmentID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Appointment_DeleteByPK");
                sqlDatabase.AddInParameter(dbCommand, "@AppointmentID", DbType.Int32, AppointmentID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        //#region Method : Product Retrive
        //public bool ProductRetrive(int ProductID)
        //{
        //    try
        //    {
        //        SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
        //        DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Product_Retrive");
        //        sqlDatabase.AddInParameter(dbCommand, "@ProductID", DbType.Int32, ProductID);
        //        bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
        //        return isSuccess;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        //#endregion

        //#region Method : Delete Multiple Product
        //public bool DeleteMultipleProducts(int[] ProductIDs)
        //{
        //    SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
        //    try
        //    {
        //        DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Product_DeleteMultiple");
        //        DataTable productIdsTable = new DataTable();
        //        productIdsTable.Columns.Add("ProductID", typeof(int));
        //        foreach (var productId in ProductIDs)
        //        {
        //            productIdsTable.Rows.Add(productId);
        //        }
        //        // Convert DataTable to a comma-separated string of ProductIDs
        //        string productIdsString = string.Join(",", productIdsTable.AsEnumerable().Select(row => row.Field<int>("ProductID")));

        //        // Pass the string as a parameter
        //        sqlDatabase.AddInParameter(dbCommand, "@ProductIDs", DbType.String, productIdsString);
        //        bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
        //        return isSuccess;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    } 
        //}
        //#endregion
    }
}



