using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITeacherService
    {
        Teacher Create(Teacher teacher);
        void Delete(Teacher teacher);   
        Teacher UpDate(int Id, Teacher teacher);
        Teacher GetTeacherById(int Id);
        List<Teacher> GetAllTeachers();
        List<Teacher> Search(string searchText);

    }
}
