using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using StudentApp.Core.Contract;
using StudentApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Data
{
    public class DbMigrator : IDbMigrator
    {
        private readonly StudentDbContext _db;
        public DbMigrator(StudentDbContext db)
        {
            _db = db;
        }

        public async Task RunAsync()
        {
            if (!await AllMigrationsApplied())
            {
                Console.WriteLine("Migrating Database...");
                await _db.Database.MigrateAsync();
            }

            await this.SeedAsync();
        }

        private async Task SeedAsync()
        {
            if (_db.Students.Any())
            {
                return;
            }

            // add your code
            var student1 = new Student { FirstName = "Peter", LastName = "Smith" };
            var student2 = new Student { FirstName = "Rom", LastName = "Smith" };
            var subjects = new List<Subject>
            {
                new Subject {Title = "COMP", Student = student1},
                new Subject {Title = "GSOE", Student = student1}
            };

            _db.Subjects.AddRange(subjects);
            _db.Students.Add(student1);
            _db.Students.Add(student2);

            await _db.SaveChangesAsync();
        }

        private async Task<bool> AllMigrationsApplied()
        {
            var histories = await _db.GetService<IHistoryRepository>()
                .GetAppliedMigrationsAsync();

            var applied = histories.Select(m => m.MigrationId);
            var total = _db.GetService<IMigrationsAssembly>().Migrations.Select(m => m.Key);
            return !total.Except(applied).Any();
        }
    }
}
