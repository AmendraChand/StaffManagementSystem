using FluentValidation;

namespace StaffManagementSystem.API.Validations
{
    public class StaffValidator :AbstractValidator<StaffManagementSystem.Data.Models.Staff>
    {
        public StaffValidator()
        {
            // Validate emp_number is not null, not empty and is between 1 and 20 characters
            RuleFor(staff => staff.emp_number).NotNull().WithMessage("Employee number is required")
                .NotEmpty().WithMessage("Employee number cannot be empty")
                .MaximumLength(20).WithMessage("Employee number cannot be longer than 20 characters");


            // Check first_name is not null, not empty and is between 1 and 50 characters
            RuleFor(staff => staff.first_name).NotNull().WithMessage("First Name is required")
                .NotEmpty().WithMessage("First Name cannot be empty")
                .MaximumLength(50).WithMessage("First Name cannot be longer than 50 characters");

            // Check last_name is no longer than and 50 characters
            RuleFor(staff => staff.last_name).MaximumLength(50).WithMessage("Last Name cannot be longer than 50 characters");

            // Validate Experience
            RuleFor(staff => staff.years_experience).NotNull().WithMessage("Experience is required")
                .NotEmpty().WithMessage("Experience cannot be empty");

            // Validate date_of_birth
            RuleFor(staff => staff.date_of_birth).NotNull().WithMessage("Date of birth is required")
                .NotEmpty().WithMessage("Date of birth cannot be empty")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Date of birth cannot be today or a future date ");

            // Validate Gender
            RuleFor(staff => staff.gender.Id).NotEmpty().WithMessage("Gender is required");
            
            // Validate Qualification
            RuleFor(staff => staff.qualification.Id).NotEmpty().WithMessage("Qualification is required");
        }
    }
}
