using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StaffManagementSystem.Data.Models
{
    [Table("Staff")]
    public class Staff
    {
        public int Id { get; set; }
        

        [Required]
        [MaxLength(20)]
        public string emp_number { get; set; }

        [StringLength(50)]
        [MaxLength(50)]
        public string first_name { get; set; }

        [StringLength(50)]
        [MaxLength(50)]
        public string last_name { get; set; }

        [Required]
        public DateTime date_of_birth { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal salary { get; set; }
        [Required]
        public int years_experience { get; set; }

        public virtual Gender gender { get; set; }
        public virtual Qualification qualification { get; set; }
    }
}