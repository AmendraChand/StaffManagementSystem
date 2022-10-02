namespace StaffManagementSystem.API
{
    public class Utility
    {
        public decimal calculateSalary(int YearsOfExperience, int QualificationLevel)
        {
            decimal Salary = (Decimal.Divide(QualificationLevel, 10)) * (Decimal.Divide(YearsOfExperience, 5)) * Convert.ToDecimal(100000);
            return Salary;

        }
    }
}
