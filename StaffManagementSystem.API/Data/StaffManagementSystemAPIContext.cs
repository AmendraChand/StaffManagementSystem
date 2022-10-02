using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffManagementSystem.Data.Models;

namespace StaffManagementSystem.API.Data
{
    public class StaffManagementSystemAPIContext : DbContext
    {
        public StaffManagementSystemAPIContext (DbContextOptions<StaffManagementSystemAPIContext> options)
            : base(options)
        {
        }

        public DbSet<StaffManagementSystem.Data.Models.Gender> Gender { get; set; } = default!;

        public DbSet<StaffManagementSystem.Data.Models.Qualification> Qualification { get; set; }

        public DbSet<StaffManagementSystem.Data.Models.Staff> Staff { get; set; }
    }
}
