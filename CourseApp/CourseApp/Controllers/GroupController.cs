﻿using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entities;
using ServiceLayer.Helpers.Extentions;
using System.Text.RegularExpressions;
using Group = DomainLayer.Entities.Group;
using ServiceLayer.Helpers.Constants;
using Microsoft.VisualBasic;
using ServiceLayer.Exceptions;

namespace CourseApp.Controllers
{
    public class GroupController
    {

        private readonly IGroupService _groupService;
        private readonly ITeacherService _teacherService;

        public GroupController()
        {
            _groupService = new GroupService();
            _teacherService = new TeacherService();
        }

        string pattern = "^(?!\\s+$)['.-]+$";
        string msg = " / Please enter again";
        string msgForEmptyInput = "/ If you leave it blank, there will be no change";


        public void Create()
        {

            ConsoleColor.Cyan.WriteConsole("Please, add group name: ");
        GroupName: string groupName = Console.ReadLine();
            try
            {

                if (String.IsNullOrWhiteSpace(groupName))
                {
                    ConsoleColor.Red.WriteConsole(ResponsMessages.StringMessage + msg);
                    goto GroupName;
                }
                else if(Regex.IsMatch(groupName, pattern))
                {
                    ConsoleColor.Red.WriteConsole(ResponsMessages.StringCharacterMessage + msg);
                    goto GroupName;
                }

            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
                goto GroupName;
            }





            ConsoleColor.Cyan.WriteConsole("Please, enter group capacity");
            Capacity: string capacityStr = Console.ReadLine();
            int capacity;
            bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);

            if (!isCorrectCapacity && capacity < 0)
            {
                ConsoleColor.Red.WriteConsole("Please, enter correct format capacity number");
                goto Capacity;
            }
            else if (capacity >= 25)
            {
                ConsoleColor.Red.WriteConsole("Can not be greater than 25 ");
                goto Capacity;
            }


            ConsoleColor.Cyan.WriteConsole("Please, enter teacher id for group: ");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);

            if (isCorrectId || id < 0)
            {
                try
                {
                    DomainLayer.Entities. Group group = new DomainLayer.Entities.Group() 
                    {
                        Name = groupName,
                        Capacity = capacity,
                        CreateDate = DateTime.Now,
                    };

                    _groupService.Create(id, group);

                    ConsoleColor.Green.WriteConsole
                     (  $"Id: {group.Id}, Name: {group.Name}, Capasity: {group.Capacity}," +
                        $" Create date: {group.CreateDate.ToString("dd,MM,yyyy")},"+
                        $" Teacher: {group.Teacher.Id}, {group.Teacher.Name}, {group.Teacher.Surname}," +
                        $"{group.Teacher.Age}, {group.Teacher.Address}");

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + msg);
                    goto Id;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please, enter correct format id" + msg);
                goto Id;
            }
          

        }


        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add group Id for delete");
        GroupId: string groupId = Console.ReadLine();

            int Id;

            bool isCorrectId = int.TryParse(groupId, out Id);

            if (isCorrectId)
            {
                try
                {
                    _groupService.Delete(Id);
                    ConsoleColor.Green.WriteConsole("Successfully deleted");

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add group Id again");
                    goto GroupId;
                }
            }
            else
            {

                ConsoleColor.Red.WriteConsole("Please add correct format group Id");
                goto GroupId;

            }
        }

        
        public void GetGroupById()
        {
            ConsoleColor.Cyan.WriteConsole("Please, add group Id:");
           SearchId: string searchId = Console.ReadLine();

            int id;

            bool isCorrectId = int.TryParse(searchId, out id);


            if (isCorrectId)
            {
                try
                {
                    Group group= _groupService.GetGroupById(id);

                    ConsoleColor.Green.WriteConsole($"Id: {group.Id}, Name: {group.Name}, Surname: {group.Capacity}");
                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please, enter teacher Id again");
                    goto SearchId;
                }
            }
            else
            {

                ConsoleColor.Red.WriteConsole("Please, enter correct format teacher Id");
                goto SearchId;

            }
        }



        public void GetAllGroupsByTeacherName()
        {
            ConsoleColor.Cyan.WriteConsole("Please, add groups teacher name:");
            SearchName: string teacherName = Console.ReadLine();

            if (teacherName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please, add correct format teacher name");
                goto SearchName;

            }
            else
            {

                try
                {

                    var groups = _groupService.GetAllGroupsByTeacherName(teacherName);

                    foreach (var group in groups)
                    {

                        ConsoleColor.Green.WriteConsole
                         ($"Id: {group.Id}, Name: {group.Name}, Capasity: {group.Capacity}," +
                            $" Create date: {group.CreateDate.ToString("dd,MM,yyyy")}," +
                            $" Teacher: {group.Teacher.Id}, {group.Teacher.Name}, {group.Teacher.Surname}," +
                            $"{group.Teacher.Age}, {group.Teacher.Address}");
                    }

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto SearchName;
                }



            }
        }



        public void GetGroupsByCapacity()
        {
            ConsoleColor.Cyan.WriteConsole("Please, add group capacity number:");
        CapacityStr: string CapacityStr = Console.ReadLine();

            int capacity;
            bool isCorrectCapacity = int.TryParse(CapacityStr, out capacity);

            if (isCorrectCapacity)
            {
                try
                {
                    var group = _groupService.GetGroupsByCapacity(capacity);

                    foreach (var item in group)
                    {
                        ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Capasity: {item.Capacity}");

                    }
                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto CapacityStr;
                }

            }

        }


        public void GetGroupsCount()
        {
            
                var result = _groupService.GetGroupsCount();

                ConsoleColor.Green.WriteConsole($"All group count: {result}");
            
        }



        public void SearchByName()
        {
            ConsoleColor.Cyan.WriteConsole("Please add search text:");
            SearchText: string searchText = Console.ReadLine();
            string pattern = @"^(?!\\s+$)[a-zA-Z,'. -]+$";

            if (searchText == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty text");
                goto SearchText;
            }

            try
            {

                var response = _groupService.SearchByName(searchText);

                foreach (var item in response)
                {

                   
                    ConsoleColor.Green.WriteConsole
                     (  $"Id: {item.Id}, Name: {item.Name}, Capasity: {item.Capacity}," +
                        $" Create date: {item.CreateDate.ToString("dd,MM,yyyy")},"+
                        $" Teacher: {item.Teacher.Id}, {item.Teacher.Name}, {item.Teacher.Surname}," +
                        $"{item.Teacher.Age}, {item.Teacher.Address}");


                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add search text again");
                goto SearchText;

            }
        }


        public void GetGroupsByTeacherId()
        {

            ConsoleColor.Cyan.WriteConsole("Please, enter the group teacher Id: ");
        TeacherIdStr: string teacherIdStr = Console.ReadLine();

            int id;

            bool isCorrectId = int.TryParse(teacherIdStr, out id);


            if (isCorrectId && id > 0)
            {
                try
                {

                    var response = _groupService.GetGroupsByTeacherId(id);

                    foreach (var item in response)
                    {


                        ConsoleColor.Green.WriteConsole
                         ($"Id: {item.Id}, Name: {item.Name}, Capasity: {item.Capacity}," +
                            $" Create date: {item.CreateDate.ToString("dd,MM,yyyy")}," +
                            $" Teacher: {item.Teacher.Id}, {item.Teacher.Name}, {item.Teacher.Surname}," +
                            $"{item.Teacher.Age}, {item.Teacher.Address}");


                    }

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please, enter the group teacher Id again");
                    goto TeacherIdStr;
                }
            }
            else
            {

                ConsoleColor.Red.WriteConsole("Please,enter correct the group teacher Id");
                goto TeacherIdStr;

            }
        }


        public void Update()
        {

            ConsoleColor.Cyan.WriteConsole("Please, enter group id");
        GroupId: string groupIdStr = Console.ReadLine();
            int groupId;
            bool isCoorectId = int.TryParse(groupIdStr, out groupId);

            
            
            if (!isCoorectId || groupId < 0)
            {
                ConsoleColor.Red.WriteConsole("Please enter correct format id: ");
                goto GroupId;
            }
            else
            {
                ConsoleColor.Cyan.WriteConsole("Please, enter group name");
            GroupName: string groupName = Console.ReadLine();


                ConsoleColor.Cyan.WriteConsole("Please, enter group capacity");
            GroupCapasity: string groupCapasityStr = Console.ReadLine();

                int groupCapacity;
                bool isCorrectCapacity = int.TryParse(groupCapasityStr, out groupCapacity);

                if (!isCorrectCapacity && groupCapacity < 0)
                {
                    ConsoleColor.Red.WriteConsole("Please, enter correct format capacity number");
                    goto GroupCapasity;
                }
                else if (groupCapacity >= 25)
                {
                    ConsoleColor.Red.WriteConsole("Can not be greater than 25 ");
                    goto GroupCapasity;
                }


                ConsoleColor.Cyan.WriteConsole("Please, enter the group teacher id");
            TeacherId: string teacherIdStr = Console.ReadLine();
                int teacherId;

                bool isCorrectId = int.TryParse(teacherIdStr, out teacherId);
                if (!isCorrectId)
                {

                    ConsoleColor.Red.WriteConsole("Please , enter correct format teacher id: ");
                    goto TeacherId;

                }
                try
                {
                    var response = _teacherService.GetTeacherById(teacherId);
                    if (response == null) throw new InvalidGroupException(ResponsMessages.NotFound);

                    Group group = new Group()
                    {
                        Name = groupName,
                        Capacity = groupCapacity,
                        Teacher = response
                    };

                    Group group1 = new();
                    group1 = _groupService.UpDate(groupId, group);

                    ConsoleColor.Green.WriteConsole($"Succesfully update {group.Name} {group.Teacher.Name}");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                }
            }
            
           
         



    

          
        }

    }

   
}
