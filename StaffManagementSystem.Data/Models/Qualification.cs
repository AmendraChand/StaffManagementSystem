using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManagementSystem.Data.Models
{


    [Table("Qualification")]
    public class Qualification
    {
        public int Id { get; set; }

        public int level { get; set; }

        
        [StringLength(50)]
        public string? description { get; set; }
    }
}
