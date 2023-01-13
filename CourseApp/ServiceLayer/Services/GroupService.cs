using DomainLayer.Entities;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class GroupService : IGroupService
    {
        public Group Create(Group group)
        {
            //teacher.Id = _count;
            //Teacher existTeacher = _repo.Get(m => m.Name.ToLower() == teacher.Name.ToLower());
            //if (existTeacher == null) throw new Exception("Data already exist");
            throw new NotImplementedException();
        }

        public void Delete(Group group)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroupsByTeacherName(string name)
        {
            throw new NotImplementedException();
        }

        public Group GetGroupById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupsByCapacity(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupsByTeacherId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupsCount()
        {
            throw new NotImplementedException();
        }

        public List<Group> Search(string name)
        {
            throw new NotImplementedException();
        }

        public Group UpDate(int Id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
