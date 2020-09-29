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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDapperHelper _dapperHelper;

        public DepartmentService(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }

        public List<Departments> GetDepartmentList()
        {
            var data = _dapperHelper.GetAll<Departments>("Sp_Department_List", null, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
        public Departments GetDepartmentById(int DepartmentId)
        {
            #region using dapper

            var data = _dapperHelper.Get<Departments>($"select * from tblDepartment where Id={DepartmentId}",null,commandType:CommandType.Text);
            return data;
            #endregion
        }

        public int ManageDepartment(DepartmentModel department)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", department.Id, DbType.Int32);
            dbPara.Add("Department", department.DepartmentTitle, DbType.String);

            #region using dapper
            var data = _dapperHelper.Insert<int>("Sp_Department_AddUpdate", dbPara, commandType: CommandType.StoredProcedure);

            #endregion
            return data;
        }
        public int DeleteDepartment(int DepartmentId)
        {
            var data = _dapperHelper.Execute($"delete from tblDepartment where Id={DepartmentId}", null, commandType: CommandType.Text);
            return data;
        }

    }
}
