using CoreDemo_3_0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Interface
{
    public interface IJobSchedulingService
    {
        List<JobScheduling> GetAllSchedulingList();
    }
}
