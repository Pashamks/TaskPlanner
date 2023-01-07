using DataAccessLevel.Interfaces;
using DataAccessLevel.Models;
using DataAccessLevel.Repositories;

namespace TaskPlannerTest
{
    public class TestDAL
    {
        private IEmployeeRepository employeeRepository;
        private ITaskRepository taskRepository;
        private IWorkProcessRepository workProcessRepository;
        [SetUp]
        public void Setup()
        {
            employeeRepository = new EmployeeRepository();
            taskRepository = new TaskRepository();
            workProcessRepository = new WorkProcessRepository();
        }

        [Test]
        public void TestGetAllEmployee()
        {
            var list = employeeRepository.GetAllAsync().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<EmployeeEntity>>(list);
        }  
        [Test]
        public void TestGetAllTasks()
        {
            var list = taskRepository.GetAllAsync().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<TaskEntity>>(list);
        }  
        [Test]
        public void TestGetAllWorks()
        {
            var list = workProcessRepository.GetAllAsync().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<WorkProcessEntity>>(list);
        }

        [Test]
        public void TestAddEmployee()
        {
            employeeRepository.AddAsync(new EmployeeEntity
            {
                Name = "user",
                FreeHours = 9
            });
            var list = employeeRepository.GetAllAsync().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<EmployeeEntity>>(list);
            Assert.IsTrue(list.Last().Name == "user");
        }  
        [Test]
        public void TestAddTask()
        {
            taskRepository.AddAsync(new TaskEntity
            {
                Title = "Task",
                HoursEstimate = 5
            });
            var list = taskRepository.GetAllAsync().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<TaskEntity>>(list);
            Assert.IsTrue(list.Last().Title == "Task");
        }
        [Test]
        public void TestAddWork()
        {
            workProcessRepository.AddAsync(new WorkProcessEntity
            {
                EmployeeId = 1,
                TaskId = 1
            });
            var list = workProcessRepository.GetAllAsync().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<WorkProcessEntity>>(list);
            Assert.IsTrue(list.Last().TaskId == 1 && list.Last().EmployeeId == 1);
        }

        [Test]
        public void TestUpdateEmployee()
        {
            employeeRepository.UpdateAsync(new EmployeeEntity
            {
                Id = 1,
                Name = "user",
                FreeHours = 9
            });
            var list = employeeRepository.GetAllAsync().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<EmployeeEntity>>(list);
            Assert.IsTrue(list.Last().Name == "user");
        }  
        [Test]
        public void TestUpdateTask()
        {
            taskRepository.UpdateAsync(new TaskEntity
            {
                Id=2,
                Title = "Task",
                HoursEstimate = 5
            });
            var list = taskRepository.GetAllAsync().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<TaskEntity>>(list);
            Assert.IsTrue(list.First().Title == "Task");
        }
        [Test]
        public void TestUpdateWork()
        {
            workProcessRepository.AddAsync(new WorkProcessEntity
            {
                Id = 1,
                EmployeeId = 1,
                TaskId = 1
            });
            var list = workProcessRepository.GetAllAsync().Result;
            Assert.IsNotNull(list);
            Assert.IsInstanceOf<List<WorkProcessEntity>>(list);
            Assert.IsTrue(list.First().TaskId == 1 && list.First().EmployeeId == 1);
        }
    }
}