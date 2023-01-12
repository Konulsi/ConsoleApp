using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Enums
{
    public enum Options
    {
        CreateTeacher =1,
        UpdateTeacher,
        DeleteTeacher,
        GetTeacherById,
        GetAllTeachers,
        SearchForTeacherNameAnSurname,
        CreateGroup,
        UpdateGroup,
        GetGroupById,
        DeleteGroup,
        GetGroupsByCapacity,
        GetGroupsBTeacherId,
        GetAllGroupsByTeacherName,
        SearchForGroupByName,
        GetAllGroupsCount

    }
}
