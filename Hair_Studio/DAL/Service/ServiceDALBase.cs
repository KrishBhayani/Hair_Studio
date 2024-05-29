using System;
using System.Data;
using System.Data.Common;
using Hair_Studio.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Hair_Studio.Areas.Service.Models;

namespace Hair_Studio.DAL.Service
{
	public class ServiceDALBase:DALHelper
	{
        #region Method : Service SelectAll
        public DataTable ServiceSelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Service_SelectAll");
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

        #region Method : Service Insert and Update
        public bool ServiceSave(ServiceModel serviceModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (serviceModel.ServiceID == 0)
                {
                    if (serviceModel.ServiceImage != null)
                    {
                        string FilePath = "wwwroot\\images";
                        string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string fileNameWithPath = Path.Combine(path, serviceModel.ServiceImage.FileName);

                        serviceModel.ImageURL = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + serviceModel.ServiceImage.FileName;

                        using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            serviceModel.ServiceImage.CopyTo(fileStream);
                        }
                    }
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Service_Insert");

                    sqlDatabase.AddInParameter(dbCommand, "@ServiceName", DbType.String, serviceModel.ServiceName);
                    sqlDatabase.AddInParameter(dbCommand, "@Price", DbType.String, serviceModel.Price);
                    sqlDatabase.AddInParameter(dbCommand, "@Description", DbType.String, serviceModel.Description);
                    sqlDatabase.AddInParameter(dbCommand, "@ImageURL", DbType.String, serviceModel.ImageURL);

                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {
                   
                        if (serviceModel.ServiceImage != null)
                        {
                            string FilePath = "wwwroot\\images";
                            string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            string fileNameWithPath = Path.Combine(path, serviceModel.ServiceImage.FileName);

                            serviceModel.ImageURL = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + serviceModel.ServiceImage.FileName;

                            using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                            {
                                serviceModel.ServiceImage.CopyTo(fileStream);
                            }
                        }
                        DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Service_UpdateByPK");
                        sqlDatabase.AddInParameter(dbCommand, "@ServiceID", DbType.Int64, Convert.ToInt64(serviceModel.ServiceID));
                        sqlDatabase.AddInParameter(dbCommand, "@ServiceName", DbType.String, serviceModel.ServiceName);
                        sqlDatabase.AddInParameter(dbCommand, "@Price", DbType.String, serviceModel.Price);
                        sqlDatabase.AddInParameter(dbCommand, "@Description", DbType.String, serviceModel.Description);
                        sqlDatabase.AddInParameter(dbCommand, "@ImageURL", DbType.String, serviceModel.ImageURL);

                        sqlDatabase.ExecuteNonQuery(dbCommand);
                        return true;
                    
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Service By ID
        public ServiceModel ServiceByID(int ServiceID)
        {
            ServiceModel serviceModel = new ServiceModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Service_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@ServiceID", DbType.Int32, ServiceID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    serviceModel.ServiceID = Convert.ToInt32(dataRow["ServiceID"]);
                    serviceModel.ServiceName = dataRow["ServiceName"].ToString();
                    serviceModel.Price = Convert.ToDecimal(dataRow["Price"]);
                    serviceModel.Description = dataRow["Description"].ToString();
                    serviceModel.ImageURL = dataRow["ImageURL"].ToString();
                }
                return serviceModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : Service Delete
        public bool ServiceDelete(int ServiceID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Service_DeleteByPK");
                sqlDatabase.AddInParameter(dbCommand, "@ServiceID", DbType.Int32, ServiceID);
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

