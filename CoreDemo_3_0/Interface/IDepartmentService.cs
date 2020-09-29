using CoreDemo_3_0.Entities;
using CoreDemo_3_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Interface
{
   public interface IDepartmentService
    {
        List<Departments> GetDepartmentList();
        Departments GetDepartmentById(int DepartmentId);
        int ManageDepartment(DepartmentModel department);
        int DeleteDepartment(int DepartmentId);
    }
}
