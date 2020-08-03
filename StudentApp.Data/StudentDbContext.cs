using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(e =>
            {
                e.HasMany(x => x.Subjects).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            });
        }
    }
}
