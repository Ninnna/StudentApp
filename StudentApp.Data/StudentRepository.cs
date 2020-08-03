using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Contract;
using StudentApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _db;
        public StudentRepository(StudentDbContext db)
        {
            _db = db;
        }
        public async Task<List<Student>> GetAllAsync()
        {
            var result = await _db.Students.Include(x => x.Subjects).ToListAsync();
            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
