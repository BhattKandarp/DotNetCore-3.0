using CoreDemo_3_0.Entities;
using CoreDemo_3_0.Models;
using CoreDemo_3_0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Interface
{
    public interface IVacancyService
    {
        List<JobVacancy> GetVacancyList();
    }
}
