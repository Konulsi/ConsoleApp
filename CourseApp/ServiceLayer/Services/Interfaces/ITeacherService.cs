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
        void Delete(int? id);   
        Teacher UpDate(int id, Teacher teacher);
        Teacher GetTeacherById(int? id);
        List<Teacher> GetAllTeachers();
        List<Teacher> Search(string searchText);

    }
}
