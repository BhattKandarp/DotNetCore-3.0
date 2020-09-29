using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Entities
{
    public class Job
    {
        [Key]
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public int CityId { get; set; }
        public string JobImage { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBY { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string UpdatedBY { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }

    public class EmployeeJob
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }

        public float Sallery { get; set; }
        public string Desination { get; set; }
        
    }
}
