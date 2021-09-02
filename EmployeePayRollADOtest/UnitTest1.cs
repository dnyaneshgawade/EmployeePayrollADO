using EmployeePayRollADO;
using NUnit.Framework;

namespace EmployeePayRollADOtest
{
    public class Tests
    {
        EmployeePayrollOperations emp = new EmployeePayrollOperations();
        
        [Test]
        public void GivenEmployeeDetail_ShouldMatchWithUpdatedDetails()
        {
            int expected = 1;
            int actual = emp.UpdateEmployee();
            Assert.AreEqual(expected, actual);
        }
    }
}