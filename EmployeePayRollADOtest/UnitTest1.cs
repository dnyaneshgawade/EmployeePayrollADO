using EmployeePayRollADO;
using NUnit.Framework;

namespace EmployeePayRollADOtest
{
    public class Tests
    {
        EmployeePayrollOperations emp = new EmployeePayrollOperations();
        
        [Test]
        public void GivenEmployeeDetail_AfterExicuteQuery_ShouldReturnExactUpdatedRecord()
        {
            int expected = 1;
            int actual = emp.UpdateEmployee();
            Assert.AreEqual(expected, actual);
        }

    }
}