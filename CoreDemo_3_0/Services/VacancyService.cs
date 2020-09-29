using CoreDemo_3_0.Entities;
using CoreDemo_3_0.Interface;
using CoreDemo_3_0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Services
{
    public class VacancyService: IVacancyService
    {
        private readonly IDapperHelper _dapperHelper;

        public VacancyService(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public List<JobVacancy> GetVacancyList()
        {
            var data = _dapperHelper.GetAll<JobVacancy>("SP_Vacancy_List", null,commandType:CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}
