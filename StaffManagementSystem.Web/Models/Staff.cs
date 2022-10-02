using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StaffManagementSystem.Web.Models
{
    public class Staff 
    {
        public int Id { get; set; }

        [Display(Name = "Employee Number")]
        [MaxLength(20, ErrorMessage = "Employee number cannot be longer than 20 characters")]
        public string emp_number { get; set; }
        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string first_name { get; set; }
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        public string last_name { get; set; }
        [Display(Name = "Date of Birth")]

       
        public DateTime date_of_birth { get; set; }
        public decimal salary { get; set; }
        [Display(Name = "Years of Experience")]
        public int years_experience { get; set; }
        [Display(Name = "Gender")]
        public virtual Gender gender { get; set; }
        [Display(Name = "Qualification")]
        public virtual Qualification qualification { get; set; }
    }
}