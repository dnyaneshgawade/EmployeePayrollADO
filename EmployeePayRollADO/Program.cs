using System;
using System.Collections.Generic;

namespace EmployeePayRollADO
{
    class Program
    {
        public static List<Employee> EmpList = new List<Employee>();
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome To Employee PayRoll Service!");
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
           // Console.WriteLine(employeePayrollOperations.GetAllEmployeeDetails());

           // employeePayrollOperations.GetAllEmployees();
            employeePayrollOperations.EmpDetails();
        }
    }
}
