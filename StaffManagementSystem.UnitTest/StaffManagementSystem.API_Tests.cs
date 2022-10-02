using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffManagementSystem.API;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace StaffManagementSystem.UnitTest
{
   
    public class SalaryCalculator
    {
        [Theory]

        [InlineData(5, 2, 20000)]
        [InlineData(6, 4, 48000)]
        [InlineData(7, 6, 84000)]
        [InlineData(8, 8, 128000)]
        [InlineData(5, 8, 80000)]
        [InlineData(5, 10, 100000)]
        [InlineData(7, 15, 210000)]
        [InlineData(0, 10, 0)]
        [InlineData(7, 0, 0)]
        public void CalculateSalary(int YearsOfExperience, int QualificationLevel, decimal expected_salary)
        {

            Utility utility = new Utility();
            decimal salary = utility.calculateSalary(YearsOfExperience, QualificationLevel);

            Assert.AreEqual(salary, expected_salary);

        }

        [Fact]
        public void calculateSalary2()
        {
            int YearsOfExperience = 5;
            int QualificationLevel = 2;
            decimal expected_salary = 20000;
            Utility utility = new Utility();
            decimal salary = utility.calculateSalary(YearsOfExperience, QualificationLevel);

            Assert.AreEqual(salary, expected_salary);

        }
    }
}
