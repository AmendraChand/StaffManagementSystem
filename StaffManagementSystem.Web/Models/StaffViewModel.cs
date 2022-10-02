using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StaffManagementSystem.Web.Models
{
    public class StaffViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Number is Required")]
        [Display(Name = "Employee Number")]
        [MaxLength(20, ErrorMessage = "First Name Cannot be more than 50 character long")]

        public string emp_number { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [MaxLength(50, ErrorMessage = "Last Name Cannot be more than 50 character long")]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public string date_of_birth { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal salary { get; set; }

        [Required(ErrorMessage = "Years of Experience is Required")]
        [Display(Name = "Years of Experience")]
        [Range(0, 100, ErrorMessage = "Enter a value between 0 and 100")]
        public int years_experience { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender")]
        public virtual Gender gender { get; set; }

        [Required(ErrorMessage = "Qualification is Required")]
        [Display(Name = "Qualification")]
        public virtual Qualification qualification { get; set; }
        public SelectList? GenderDropDownList { get; set; }
        public SelectList? QualificationDropDownList { get; set; }
    }
}
