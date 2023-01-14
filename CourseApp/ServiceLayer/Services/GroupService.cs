using DomainLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Exceptions;
using ServiceLayer.Helpers.Constants;
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

        private readonly GroupRepository _repo;
        private int _count = 1;

        public GroupService()
        {
            _repo = new GroupRepository();
        }


        public Group Create(Group group)
        {
            group.Id = _count;

            Group existGroup = _repo.Get(m => m.Name.ToLower() == group.Name.ToLower());
            if (existGroup != null) throw new Exception("Data already exist");

            _repo.Create(group);
            _count++;
            return group;
        }

        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            Group dbGroup = _repo.Get(m => m.Id == id);

            if (dbGroup == null) throw new NullReferenceException("Data notfound");

            _repo.Delete(dbGroup);
        }

        public Group GetGroupById(int? id)
        {

            if (id == null) throw new InvalidTeacherException(ResponsMessage.NotFound);

            return _repo.Get(m => m.Id == id);
        }

        public List<Group> GetAllGroupsByTeacherName(string teacherName)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupsByCapacity(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupsByTeacherId(int? id)
        {
            if (id == null) throw new InvalidTeacherException(ResponsMessage.NotFound);

            Group dbGroup = _repo.Get(m => m.Id == id);

            if (dbGroup == null) throw new InvalidTeacherException(ResponsMessage.NotFound);

            return _repo.GetAll(m=> m.Teacher.Id == id);
            
        }

        public int GetGroupsCount()
        {
            throw new NotImplementedException();
        }

        public List<Group> Search(string search)
        {
            throw new NotImplementedException();
        }

        public Group UpDate(int? id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
