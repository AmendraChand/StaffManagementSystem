using StaffManagementSystem.Web;


namespace StaffManagementSystem.Web.Models.Mappers
{
    public class StaffMapper
    {
        public Staff StaffViewModelToStaffModel(StaffViewModel staffViewModel)
        {
          

            var Staff = new Staff();
            Staff.Id = staffViewModel.Id;
            Staff.emp_number = staffViewModel.emp_number;
            Staff.first_name = staffViewModel.first_name;
            Staff.last_name = staffViewModel.last_name;
            Staff.date_of_birth = Convert.ToDateTime(staffViewModel.date_of_birth);
            Staff.gender = staffViewModel.gender;
            Staff.gender.Id = staffViewModel.gender.Id;
            Staff.years_experience = staffViewModel.years_experience;
            Staff.qualification = staffViewModel.qualification;
            Staff.qualification.Id = staffViewModel.qualification.Id;
            return Staff;

        }
    }
}
