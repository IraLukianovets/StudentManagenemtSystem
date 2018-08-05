using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DAL.Entities;

namespace StudentSystem.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
    }
}
