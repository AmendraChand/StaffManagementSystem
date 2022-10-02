using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManagementSystem.Web.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public int level { get; set; }
        public string? description { get; set; }
    }
}
