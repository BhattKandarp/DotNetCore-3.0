using CoreDemo_3_0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Interface
{
   public interface IJobService
    {
        int Delete(int JobId);
        Job GetByJobId(int JobId);
        string Update(Job job);
        int Create(Job JobDetails);
        List<Job> ListAll();

        List<EmployeeJob> ListOfEmployeeJob();
    }
}
