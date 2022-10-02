using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManagementSystem.Data.Models
{


    [Table("Gender")]
    public class Gender
    {
        public int Id { get; set; }

       
        [StringLength(20)]
        public string? description { get; set; }
    }
}
