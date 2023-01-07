using AutoMapper;
using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Models;
using DataAccessLevel.Interfaces;
using DataAccessLevel.Models;

namespace BusinessLogicLevel.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task AddEmployee(EmployeeModel employee)
        {
            await _employeeRepository.AddAsync(_mapper.Map<EmployeeEntity>(employee));
        }

        public async Task<List<EmployeeModel>> GetEmployees()
        {
            var list = await _employeeRepository.GetAllAsync();
            return list.Select(x => _mapper.Map<EmployeeModel>(x)).ToList();
        }
    }
}
