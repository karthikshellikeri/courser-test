using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Employee
    {
        public int ProjectID { get; set; }
        public int JobCode { get; set; }
        public string FacilityID { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public int EmpID { get; set; }
        public bool IsActive { get; set; }
    }
}
