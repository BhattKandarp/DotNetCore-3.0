using CoreDemo_3_0.Entities;
using CoreDemo_3_0.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Services
{
    public class JobSchedulingService:IJobSchedulingService
    {
        private readonly IDapperHelper _dapperhelper;
        public JobSchedulingService(IDapperHelper dapperhelper)
        {
            _dapperhelper = dapperhelper;

        }

      public List<JobScheduling> GetAllSchedulingList()
        {
            var data = _dapperhelper.GetAll<JobScheduling>("dbo.SP_JobScheduling_List", null, commandType: System.Data.CommandType.StoredProcedure);
            return data;
        }
    }
}
