using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayRollADO
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public DateTime Startdate { get; set; }
        public double Salary { get; set; }
    }
}
