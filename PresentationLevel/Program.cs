using AutoMapper;
using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Managers;
using BusinessLogicLevel.Mapper;
using BusinessLogicLevel.Models;
using DataAccessLevel.Enums;
using DataAccessLevel.Repositories;

namespace PresentationLevel
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mapper = new Mapper(new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            }));
            ITaskManager taskManager = new TaskManager(new TaskRepository(), new WorkProcessRepository(), mapper);

            IEmployeeManager employeeManager = new EmployeeManager(new EmployeeRepository(), mapper);

            int input = 0, isFinished = 1;
            HttpClient client = new HttpClient();

            Console.WriteLine("Welcome to Task Planner!");
       
            while (isFinished != 0)
            {
                Console.WriteLine("\nChoose action:\n" +
                    "0 - Finish working\n" +
                    "1 - Show all tasks\n" +
                    "2 - Show all employee\n" +
                    "3 - Add new task\n" +
                    "4 - Close existing task\n" +
                    "5 - Sing task to employee\n" +
                    "6 - Add employee\n");

                input = Convert.ToInt32(Console.ReadLine());
                if (input == 0)
                    break;
                else if (input == 1)
                {
                    var list = taskManager.GetAllTasks().Result;
                    foreach (var item in list)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine(item.Id + " | " + item.Title + " | " + item.Priority + " | " + item.HoursEstimate + "|");
                    }
                }
                else if (input == 2)
                {
                    var list = employeeManager.GetEmployees().Result;
                    foreach (var item in list)
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine(item.Id + " | " + item.Name + " | " + item.FreeHours + " | ");
                    }
                }
                else if (input == 3)
                {
                    Console.WriteLine("Enter task title:");
                    var title = Console.ReadLine();
                    Console.WriteLine("Enter task estimate:");
                    var estimate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter prioprity:");
                    var priority = (Console.ReadLine());

                    taskManager.AddNewTask(new TaskModel
                    {
                        Title = title,
                        HoursEstimate = estimate,
                        Priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), priority)
                    }) ;
                }
                else if (input == 4)
                {
                    Console.WriteLine("Enter task id:");
                    var taskId = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Enter work process id:");
                    var workid = Convert.ToInt32(Console.ReadLine());


                    taskManager.CloseTask(new WorkProcessModel 
                    { 
                        Id = workid,
                        TaskId = taskId,
                        Status = TaskModelStatus.Closed
                    });

                }
                else if (input == 5)
                {
                    int taskId, empoloyeeId;
                    Console.WriteLine("Enter employee id:");
                    empoloyeeId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter task id:");
                    taskId = Convert.ToInt32(Console.ReadLine());
                    taskManager.SignTaskToEmployee(new WorkProcessModel
                    {
                        TaskId = taskId,
                        EmployeeId = empoloyeeId,
                        Status = TaskModelStatus.New                     
                    });
                }
                else if ( input == 6)
                {
                    string name;
                    int freeHours;
                    Console.WriteLine("Enter employee name:");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter product free hours:");
                    freeHours = Convert.ToInt32(Console.ReadLine());
                    employeeManager.AddEmployee(new EmployeeModel
                    {
                        Name = name,
                        FreeHours = freeHours
                    });
                    
                }
            }
        }
    }
}
