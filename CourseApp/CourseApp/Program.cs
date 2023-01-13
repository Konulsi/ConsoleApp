



using CourseApp.Controllers;
using ServiceLayer.Helpers.Enums;
using ServiceLayer.Helpers.Extentions;

TeacherController teacherController = new();


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
                Console.WriteLine("Uptade");
                break;
            case (int)Options.DeleteTeacher:
                teacherController.Delete();
                break;
            case (int)Options.GetTeacherById:
                teacherController.GetTeacherById();
                break;
            case (int)Options.GetAllTeachers:
                teacherController.GetAll();
                break;
            case (int)Options.SearchForTeacherNameAnSurname:
                teacherController.Search();
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
    ConsoleColor.Cyan.WriteConsole("Teacher options: \n 1 - Create Teacher,  \n 2 - Update Teacher, \n 3 - Delete Teacher, \n 4 - Get Teacher By Id, \n 5 - Get All Teachers, \n 6 - Search Teacher For Name And Surname");
}