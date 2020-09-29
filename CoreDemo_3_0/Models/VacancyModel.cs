using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Models
{
    public class VacancyModel
    {
        public int Id { get; set; }
        public string Vacancy { get; set; }
        public int DepartmentId { get; set; }
        public int NoOfPosition { get; set; }
        public int NoOfExperience { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
