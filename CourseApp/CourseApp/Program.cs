



using CourseApp.Controllers;
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
            case (int)Options.CreateTeacher:
                teacherController.Create();
                break;
            case (int)Options.UpdateTeacher:
                teacherController.Update();
                break;
            case (int)Options.DeleteTeacher:
                teacherController.Delete();
                break;
            case (int)Options.GetTeacherById:
                teacherController.GetTeacherById();
                break;
            case (int)Options.GetAllTeachers:
                Console.WriteLine();
                Console.WriteLine("All teachers:");
                teacherController.GetAll();
                break;
            case (int)Options.SearchForTeacherNameAnSurname:
                teacherController.Search();
                break;
            case (int)Options.CreateGroup:
                groupController.Create();
                break;
            case (int)Options.UpdateGroup:
                Console.WriteLine("Update");
                break;
            case (int)Options.DeleteGroup:
                groupController.Delete();
                break;
            case (int)Options.GetGroupById:
                groupController.GetGroupById();
                break;
            case (int)Options.GetGroupsByCapacity:
                groupController.GetGroupsByCapacity();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please add correct option");
                goto Option;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please add correct format option");
        goto Option;
    }

}



static void GetOptions()
{
    ConsoleColor.Cyan.WriteConsole("Please select one option: ");
    ConsoleColor.Cyan.WriteConsole("Teacher options: \n 1 - Create Teacher,  \n 2 - Update Teacher, \n 3 - Delete Teacher, \n 4 - Get Teacher By Id, \n 5 - Get All Teachers, \n 6 - Search Teacher For Name And Surname \n " +
        "Group Options:\n 7 - Create Group \n 8 - Update Group \n 9 - Delete Group \n 10 - GetGroupById \n 11 - GetGroupsByCapacity \n 12 - GetGroupsByTeacherId \n 13 - GetAllGroupsByTeacherName \n 14 - SearchForGroupByName \n 15 - GetAllGroupsCount ");
}


