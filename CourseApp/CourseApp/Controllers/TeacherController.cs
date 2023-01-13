using DomainLayer.Entities;
using ServiceLayer.Helpers.Extentions;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    public class TeacherController
    {
        private readonly ITeacherService _teacherService;

        public TeacherController()
        {
            _teacherService = new TeacherService();
        }


        public void Create()
        {
            ConsoleColor.Cyan.WriteConsole("Please ad teacher name: ");
            TeacherName: string teacherName = Console.ReadLine();
            string pattern = "^(?!\\s+$)[a-zA-Z]+$";

            if (teacherName == string.Empty )
            {
                ConsoleColor.Red.WriteConsole("Please dont empty teacher name");
                goto TeacherName;
            }
            else if (!Regex.IsMatch(teacherName , pattern))
            {
                ConsoleColor.Red.WriteConsole("Please correct teacher name");
                goto TeacherName;
            }



            ConsoleColor.Cyan.WriteConsole("Please ad teacher surname: ");
            TeacherSurname: string teacherSurname = Console.ReadLine();
            

            if (teacherSurname == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty teacher surname");
                goto TeacherSurname;
            }
            else if (!Regex.IsMatch(teacherSurname, pattern))
            {
                ConsoleColor.Red.WriteConsole("Please correct teacher surname");
                goto TeacherSurname;
            }


            ConsoleColor.Cyan.WriteConsole("Please ad teacher address: ");
            TeacherAddress: string teacherAddress = Console.ReadLine();

            if (teacherAddress == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty teacher address");
                goto TeacherAddress;
            }
          


            ConsoleColor.Cyan.WriteConsole("Please ad teacher Age: ");
            TeacherAge: string teacherAge = Console.ReadLine();

            int age;
            bool isCorrectAge = int.TryParse(teacherAge, out age);

            if (isCorrectAge)
            {
                try
                {
                    Teacher teacher = new Teacher()
                    {
                        Name = teacherName,
                        Surname= teacherSurname,
                        Address = teacherAddress,
                        Age = age

                    };

                    var response = _teacherService.Create(teacher);

                    ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Name: {response.Name}, Surname: {response.Surname}, Address: {response.Address}, Age: {response.Age}");

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher name again!");
                    goto TeacherName;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format age");
                goto TeacherAge;
            }

        }

        public void GetAll()
        {
            var result = _teacherService.GetAllTeachers();

            if (result.Count == 0)
            {
                ConsoleColor.Cyan.WriteConsole("Data not found");
            }
            else
            {
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Address: {item.Address}, Age: {item.Age}");
                }
            }

        }


        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher Id for delete");
            TeacherId: string teacherId = Console.ReadLine();

            int Id;

            bool isCorrectId = int.TryParse(teacherId, out Id);

            if (isCorrectId)
            {
                try
                {
                    _teacherService.Delete(Id);
                    ConsoleColor.Green.WriteConsole("Successfully deleted");

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher Id again");
                    goto TeacherId;
                }
            }
            else
            {

                ConsoleColor.Red.WriteConsole("Please add correct format teacher Id");
                goto TeacherId;

            }

        }


        public void Search()
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

                var response = _teacherService.Search(searchText);

                foreach (var item in response)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Address: {item.Address}, Age: {item.Age}");
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher Id again");
                goto SearchText;

            }

        }


        public void GetTeacherById()
        {

            ConsoleColor.Cyan.WriteConsole("Please, add teacher Id:");
            SearchId: string searchId = Console.ReadLine();

            int id;

            bool isCorrectId = int.TryParse(searchId, out id);


            if (isCorrectId)
            {
                try
                {

                    var response = _teacherService.GetTeacherById(id);

                   
                        ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Name: {response.Name}, Surname: {response.Surname}, Address: {response.Address}, Age: {response.Age}");
                    
                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please, add teacher Id again");
                    goto SearchId;
                }
            }
            else
            {

                ConsoleColor.Red.WriteConsole("Please, add correct format teacher Id");
                goto SearchId;

            }

        }

        public void Update()
        {

            ConsoleColor.Cyan.WriteConsole("Please, add teacher id");
            TeacherId: string TeacherIdStr = Console.ReadLine();
            int teacherId;
            bool isCoorectId = int.TryParse(TeacherIdStr, out teacherId);
            
            if (!isCoorectId)
            {
                ConsoleColor.Red.WriteConsole("Please add correct format id: ");
                goto TeacherId;
            }



            ConsoleColor.Cyan.WriteConsole("Please, add teacher name");
            TeacherName: string teacherName = Console.ReadLine();
            string pattern2 = "^(?!\\s+$)[a-z A-Z]+$";

            try
            {
                //if (!Regex.IsMatch(teacherName, pattern2))
                //{
                //    ConsoleColor.Red.WriteConsole("Please, add correct teacher name");
                //    goto TeacherName;
                //}

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please, add teacher name again: ");
                goto TeacherName;
            }

            ConsoleColor.Cyan.WriteConsole("Please, add teacher surname");
            TeacherSurname: string teacherSurname = Console.ReadLine();
            try
            {
                if (!Regex.IsMatch(teacherSurname, pattern2))
                {
                    ConsoleColor.Red.WriteConsole("Please, add correct teacher surname");
                    goto TeacherSurname;
                }

            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please, add teacher surname again: ");
                goto TeacherSurname;
            }

            ConsoleColor.Cyan.WriteConsole("Please, add teacher address");
            TeacherAddress: string teacherAddress = Console.ReadLine();

            try
            {
                if (!Regex.IsMatch(teacherAddress, pattern2))
                {
                    ConsoleColor.Red.WriteConsole("Please, add correct teacher address");
                    goto TeacherAddress;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please, add teacher address again: ");
                goto TeacherAddress;
            }

            ConsoleColor.Cyan.WriteConsole("Please, add teacher age");
            TeacherAge: string teacherAgeStr = Console.ReadLine();

            int teacherAge;
            bool isCorrectAge = int.TryParse(teacherAgeStr, out teacherAge);
            if (!isCorrectAge)
            {

                ConsoleColor.Red.WriteConsole("Please add correct format age: ");
                goto TeacherAge; 
                
            }
           
            if(isCoorectId)
            {
                try
                {
                    Teacher teacher = new Teacher()
                    {
                        Name = teacherName,
                        Surname = teacherSurname,
                        Address = teacherAddress,
                        Age = teacherAge,
                    };
                    Teacher teacher1 = new();
                    teacher1 = _teacherService.UpDate(teacherId, teacher);

                    ConsoleColor.Green.WriteConsole("Succesfully update");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message); 
                }
                
            }
        }

    }
}
