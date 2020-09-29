using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Entities
{
    public class JobVacancy
    {
        [Key]

        public int Id { get; set; }
        public string Vacancy { get; set; }
        public int DepartmentId { get; set; }
        public int NoOfPosition { get; set; }
        public int NoOfExperience { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Department { get; set; }
    }
}
