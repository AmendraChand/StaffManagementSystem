using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace StaffManagementSystem.Data.Models
{
    public partial class StaffManagementSystemContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public StaffManagementSystemContext(IConfiguration configuration)
        {

            Configuration = configuration;
        }


        public StaffManagementSystemContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
        }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>()
        .HasIndex(u => u.emp_number)
        .IsUnique(true);

        }
    }
}
