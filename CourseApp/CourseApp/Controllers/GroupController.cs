using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entities;
using ServiceLayer.Helpers.Extentions;
using System.Text.RegularExpressions;

namespace CourseApp.Controllers
{
    public class GroupController
    {

        private readonly IGroupService _groupService;

        public GroupController()
        {
            _groupService = new GroupService();
        }


        public void Create()
        {
            ConsoleColor.Cyan.WriteConsole("Please, enter teacher id for group: ");
        TeacherId: string teacherName = Console.ReadLine();
            int teacherId;
            bool isCorrectTeacherId = int.TryParse(teacherName, out teacherId);
            string pattern1 = "[a-zA-Z]";


            // if (Regex.IsMatch(teacherName, pattern))
            //{
            //    ConsoleColor.Red.WriteConsole("Please, correct teacher id");
            //    goto GroupName;
            //}


            ConsoleColor.Cyan.WriteConsole("Please, add group name: ");
        GroupName: string groupName = Console.ReadLine();
            string pattern = "[a-zA-Z]";

            if (groupName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please, dont add empty group name");
                goto GroupName;
            }
            //else if (Regex.IsMatch(groupName, pattern))
            //{
            //    ConsoleColor.Red.WriteConsole("Please, correct group name");
            //    goto GroupName;
            //}



            ConsoleColor.Cyan.WriteConsole("Please, add group capacity ");
        GroupCapacity: string groupCapacity = Console.ReadLine();
            int capacity;
            bool isCorrectCapacity = int.TryParse(groupCapacity, out capacity);
          
            // if (!Regex.IsMatch(groupCapacity, pattern))
            //{
            //    ConsoleColor.Red.WriteConsole("Please, correct  group capacity");
            //    goto GroupCapacity;
            //}



            if (isCorrectCapacity)
            {
                try
                {
                    DomainLayer.Entities. Group group = new DomainLayer.Entities.Group() 
                    {
                        Name = groupName,
                        Capacity = capacity,
                        CreateDate = DateTime.Now,
                       

                    };

                    var response = _groupService.Create(group);

                    ConsoleColor.Green.WriteConsole($"Teacher Id: {response.Id}, Name: {response.Name}, Capasity: {response.Capacity}, Create date: {response.CreateDate}");

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please, add try again!");
                    goto TeacherId;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format capacity");
                goto TeacherId;
            }
          

        }

    }
}
