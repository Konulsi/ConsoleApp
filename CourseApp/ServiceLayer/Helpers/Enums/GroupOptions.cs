using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Enums
{
    public enum GroupOptions
    {
        CreateGroup = 1,
        UpdateGroup,
        DeleteGroup,
        GetGroupById,
        GetGroupsByCapacity,
        GetGroupsByTeacherId,
        GetAllGroupsByTeacherName,
        SearchByName,
        GetAllGroupsCount
    }
}
