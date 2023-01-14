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
        private readonly TeacherRepository _repoTeacher;
        private int _count = 1;

        public GroupService()
        {
            _repo = new GroupRepository();
            _repoTeacher= new TeacherRepository();  
        }


        public Group Create(int ? teacherId , Group group)
        {
            Teacher existTeacher = _repoTeacher.Get(m => m.Id == teacherId);
            group.Id = _count;
            group.Teacher = existTeacher;
            if (existTeacher == null) throw new InvalidGroupException(ResponsMessages.NotFound);

            Group existGroup = _repo.Get(m => m.Name.ToLower() == group.Name.ToLower());
            if (existGroup != null) throw new InvalidGroupException(ResponsMessages.ExistMessage);

            _repo.Create(group);
            _count++;
            return group;
        }

        public void Delete(int? id)
        {
            if (id == null) throw new InvalidGroupException(ResponsMessages.NotFound);

            Group dbGroup = _repo.Get(m => m.Id == id);

            if (dbGroup == null) throw new InvalidGroupException(ResponsMessages.NotFound);

            _repo.Delete(dbGroup);
        }

        public Group GetGroupById(int? id)
        {

            if (id == null) throw new InvalidGroupException(ResponsMessages.NotFound);
            
            Group dbGroup =  _repo.Get(m => m.Id == id);
            if (dbGroup is null) throw new InvalidGroupException(ResponsMessages.NotFound);

            return dbGroup; 
        }

        public List<Group> GetAllGroupsByTeacherName(string teacherName)
        {
            if (teacherName == null) throw new InvalidGroupException(ResponsMessages.NotFound);

            List<Group> dbGroup = _repo.GetAll(m => m.Teacher.Name == teacherName);

            if (dbGroup.Count == 0) throw new InvalidGroupException(ResponsMessages.NotFound);

            return dbGroup;

        }

        public List<Group> GetGroupsByCapacity(int? capacity)
        {
            if (capacity == null) throw new InvalidGroupException(ResponsMessages.NotFound);

            List<Group> dbGroup = _repo.GetAll(m => m.Capacity == capacity);

            if (dbGroup.Count == 0) throw new InvalidGroupException(ResponsMessages.NotFound);

            return dbGroup;

        }

        public List<Group> GetGroupsByTeacherId(int? teacherId)
        {
            if (teacherId == null) throw new InvalidGroupException(ResponsMessages.NotFound);

            List<Group> dbGroup = _repo.GetAll(m => m.Teacher.Id == teacherId);

            if (dbGroup.Count == 0) throw new InvalidGroupException(ResponsMessages.NotFound);

            return dbGroup;
            
        }

        public int GetGroupsCount()
        {
            return _repo.GetAll().Count;
        }

        public List<Group> Search(string search)
        {
            List<Group> groups = _repo.GetAll(m => m.Name.ToLower().Contains(search.ToLower()));
            if(groups.Count == 0) throw new InvalidGroupException(ResponsMessages.NotFound);
            return groups;
        }

        public Group UpDate(int? id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
