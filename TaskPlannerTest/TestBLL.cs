using AutoMapper;
using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Managers;
using BusinessLogicLevel.Mapper;
using BusinessLogicLevel.Models;
using DataAccessLevel.Interfaces;
using DataAccessLevel.Models;
using DataAccessLevel.Repositories;

namespace TaskPlannerTest
{
    public class TestBLL
    {
        private IEmployeeRepository employeeRepository;
        private ITaskRepository taskRepository;
        private IWorkProcessRepository workProcessRepository;

        private ITaskManager taskManager;
        private IEmployeeManager empolyeeManager;
        [SetUp]
        public void Setup()
        {
            employeeRepository = new EmployeeRepository();
            taskRepository = new TaskRepository();
            workProcessRepository = new WorkProcessRepository();
            var mapper = new Mapper(new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            }));
            taskManager = new TaskManager(taskRepository, workProcessRepository, mapper);
            empolyeeManager = new EmployeeManager(employeeRepository, mapper);
        }

        [Test]
        public void TestGetAllEmployee()
        {
            var list = empolyeeManager.GetEmployees().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<EmployeeModel>>(list);
        }
        [Test]
        public void TestGetAllTasks()
        {
            var list = taskManager.GetAllTasks().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<TaskModel>>(list);
        }

        [Test]
        public void TestAddEmployee()
        {
            empolyeeManager.AddEmployee(new EmployeeModel
            {
                Name = "user",
                FreeHours = 9
            });
            var list = empolyeeManager.GetEmployees().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<EmployeeModel>>(list);
            Assert.IsTrue(list.Last().Name == "user");
        }
        [Test]
        public void TestAddTask()
        {
            taskManager.AddNewTask(new TaskModel
            {
                Title = "Task",
                HoursEstimate = 5
            });
            var list = taskManager.GetAllTasks().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<TaskModel>>(list);
            Assert.IsTrue(list.Last().Title == "Task");
        }

    }
}
