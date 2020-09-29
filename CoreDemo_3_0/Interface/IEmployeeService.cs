using CoreDemo_3_0.Entities;
using CoreDemo_3_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Interface
{
   public interface IEmployeeService
    {
        List<Employee> GetAllEmployeeList();
        Employee GetEmployeeById(int employeeid);
        int AddUpdateEmployee(EmployeeModel model);
        int DeleteEmployee(int Id);
    }
}
