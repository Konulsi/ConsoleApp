using DomainLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        void Delete(int ? id);
        Group UpDate(int ? id, Group group);
        Group GetGroupById(int ? id);
        List<Group> GetGroupsByCapacity(int ? id);
        List<Group> GetGroupsByTeacherId(int ? id);
        List<Group> GetAllGroupsByTeacherName(string teacherName);
        List<Group> Search(string search);
        int GetGroupsCount();

    }
}






