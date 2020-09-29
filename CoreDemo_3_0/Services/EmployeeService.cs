using CoreDemo_3_0.Entities;
using CoreDemo_3_0.Interface;
using CoreDemo_3_0.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IDapperHelper _dapperHelper;

        public EmployeeService(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }
        public List<Employee> GetAllEmployeeList()
        {
            var data = _dapperHelper.GetAll<Employee>("dbo.SP_Employee_List", null, commandType:CommandType.StoredProcedure);
            return data.ToList();
        }

        public Employee GetEmployeeById(int employeeid)
        {
            var data = _dapperHelper.Get<Employee>($"select * from tblEmployee where Id={employeeid}", null, commandType: CommandType.Text);
            return data;
        }

        public int AddUpdateEmployee(EmployeeModel model)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", model.Id, DbType.Int32);
            dbPara.Add("Firstname", model.Firstname, DbType.String);
            dbPara.Add("Lastname", model.Lastname, DbType.String);
            dbPara.Add("Email", model.Email, DbType.String);
            dbPara.Add("Mobile", model.Mobile, DbType.String);
            dbPara.Add("DOB", model.DOB, DbType.DateTime);
            dbPara.Add("Image", model.Image, DbType.String);

            #region ADD/UPDATE USING DAPPER
            var data = _dapperHelper.Insert<int>("dbo.SP_Manage_Employee", dbPara, commandType: CommandType.StoredProcedure);
            return data;
            #endregion
            
        }

        public int DeleteEmployee(int Id)
        {
            var data = _dapperHelper.Execute($"delete from tblEmployee where Id={Id}", null, commandType: CommandType.Text);
            return data;
        }
    }
}
