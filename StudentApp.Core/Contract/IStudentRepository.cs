using StudentApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Core.Contract
{
    public interface IStudentRepository : IRepository
    {
        Task<List<Student>> GetAllAsync();
    }
}
