using DomainLayer.Entities;
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
        void Delete(Group group);
        Group UpDate(int Id, Group group);
        Group GetGroupById(int Id);
        List<Group> GetGroupsByCapacity(int Id);
        List<Group> GetGroupsByTeacherId(int Id);
        List<Group> GetAllGroupsByTeacherName(string name);
        List<Group> Search(string name);
        List<Group> GetGroupsCount();

    }
}
