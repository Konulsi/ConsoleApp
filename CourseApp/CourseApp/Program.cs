



using CourseApp.Controllers;
using Microsoft.VisualBasic;
using ServiceLayer.Helpers.Enums;
using ServiceLayer.Helpers.Extentions;

TeacherController teacherController = new();
GroupController groupController = new();


while (true)
{

    GetOptions();


Option: string option = Console.ReadLine();

    int selectedOption;

    bool isCorrectOption = int.TryParse(option, out selectedOption);

    if (isCorrectOption)
    {
        switch (selectedOption)
        {
            case (int)Options.TeacherOptions:
                ConsoleColor.Cyan.WriteConsole(" \n 1 - Create Teacher,  \n 2 - Update Teacher, \n 3 - Delete Teacher, \n 4 - Get Teacher By Id, \n 5 - Get All Teachers, \n 6 - Search Teacher For Name And Surname \n 7 - Back to menu ");
            TeacherOptions: string option1 = Console.ReadLine();
                int teacherOptions;
                bool isTeacherOptions = int.TryParse(option1, out teacherOptions);
                if (isTeacherOptions)
                {

                    switch (teacherOptions)
                    {
                        case (int)TeacherOptions.CreateTeacher:
                            teacherController.Create();
                            break;
                        case (int)TeacherOptions.UpdateTeacher:
                            teacherController.Update();
                            break;
                        case (int)TeacherOptions.DeleteTeacher:
                            teacherController.Delete();
                            break;
                        case (int)TeacherOptions.GetTeacherById:
                            teacherController.GetTeacherById();
                            break;
                        case (int)TeacherOptions.GetAllTeachers:
                            Console.WriteLine("All teachers:");
                            teacherController.GetAll();
                            break;
                        case (int)TeacherOptions.SearchForTeacherNameAnSurname:
                            teacherController.Search();
                            break;
                        case (int)BackToMenu.TeacherOption:
                            Console.Clear();
                            break;
                        default:
                            ConsoleColor.Red.WriteConsole("Please, select correct format options!");
                            goto TeacherOptions;

                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please, select correct format options!");
                    goto TeacherOptions;
                }
                break;

            case (int)Options.GroupOptions:
                ConsoleColor.Cyan.WriteConsole("\n 1 - Create Group \n 2 - Update Group \n 3 - Delete Group \n 4 - GetGroupById \n 5 - GetGroupsByCapacity \n 6 - GetGroupsByTeacherId \n 7 - GetAllGroupsByTeacherName \n 8 - SearchByName \n 9 - GetAllGroupsCount \n 10 - Back to menu");
            GroupOptions: string option2 = Console.ReadLine();
                int groupOptions;
                bool isgroupOptions = int.TryParse(option2, out groupOptions);
                if (isgroupOptions)
                {

                    switch (groupOptions)
                    {
                        case (int)GroupOptions.CreateGroup:
                            groupController.Create();
                            break;
                        case (int)GroupOptions.UpdateGroup:
                            groupController.Update();
                            break;
                        case (int)GroupOptions.DeleteGroup:
                            groupController.Delete();
                            break;
                        case (int)GroupOptions.GetGroupById:
                            groupController.GetGroupById();
                            break;
                        case (int)GroupOptions.GetGroupsByCapacity:
                            groupController.GetGroupsByCapacity();
                            break;
                        case (int)GroupOptions.GetGroupsByTeacherId:
                            groupController.GetGroupsByTeacherId();
                            break;
                        case (int)GroupOptions.GetAllGroupsByTeacherName:
                            groupController.GetAllGroupsByTeacherName();
                            break;
                        case (int)GroupOptions.SearchByName:
                            groupController.SearchByName();
                            break;
                        case (int)GroupOptions.GetAllGroupsCount:
                            groupController.GetGroupsCount();
                            break;
                        case (int)BackToMenu.GroupOption:
                            Console.Clear();
                            break;
                        default:
                            ConsoleColor.Red.WriteConsole("Please, select correct format options!");
                            goto GroupOptions;
                    }

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please, select correct format options!");
                    goto GroupOptions;
                }
                break;
        }


    }



    static void GetOptions()
    {
        ConsoleColor.Cyan.WriteConsole("Please select one option: ");
        ConsoleColor.Cyan.WriteConsole("1 - Teacher options \n2 - Group options");
    }


}