using AutoMapper;
using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Models;
using DataAccessLevel.Interfaces;
using DataAccessLevel.Models;

namespace BusinessLogicLevel.Managers
{
    public class TaskManager : ITaskManager
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IWorkProcessRepository _workRepository;
        private readonly IMapper _mapper;
        public TaskManager(ITaskRepository taskRepository, IWorkProcessRepository workProcessRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _workRepository = workProcessRepository;
            _mapper = mapper;
        }
        public async Task AddNewTask(TaskModel task)
        {
            await _taskRepository.AddAsync(_mapper.Map<TaskEntity>(task));
        }

        public async Task CloseTask(WorkProcessModel task)
        {
            await _workRepository.UpdateAsync(_mapper.Map<WorkProcessEntity>(task));
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return tasks.Select(x => _mapper.Map<TaskModel>(x)).ToList();
        }

        public async Task SignTaskToEmployee(WorkProcessModel work)
        {
            await _workRepository.AddAsync(_mapper.Map<WorkProcessEntity>(work));
        }
    }
}
