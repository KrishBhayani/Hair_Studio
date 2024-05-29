using System;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using Hair_Studio.Areas.Service.Models;

namespace Hair_Studio.DAL.Stylist
{
	public class StylistDAL:StylistDALBase
	{
        #region Service DropDown
        public List<ServiceDropdownModel> ServiceDropdownModel()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Service_Dropdown");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<ServiceDropdownModel> listOfCategories = new List<ServiceDropdownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    ServiceDropdownModel serviceDropdownModel = new ServiceDropdownModel();
                    serviceDropdownModel.ServiceID = Convert.ToInt32(dataRow["ServiceID"]);
                    Console.WriteLine("Hello "+serviceDropdownModel.ServiceID);
                    serviceDropdownModel.ServiceName = dataRow["ServiceName"].ToString();
                    listOfCategories.Add(serviceDropdownModel);
                }
                return listOfCategories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}

