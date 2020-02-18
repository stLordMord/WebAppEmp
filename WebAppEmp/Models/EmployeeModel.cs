using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEmp.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime StartDate { get; set; }
        public string Post { get; set; }
        public int CompanyId { get; set; }
    }
}