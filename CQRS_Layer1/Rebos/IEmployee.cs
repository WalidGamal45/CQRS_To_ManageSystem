using CQRS_Layer1.Dmains;

namespace CQRS_Layer1.Rebos
{
    public interface IEmployee
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployeeById(int id);
        public void AddEmployee(Employee employee);
        public Employee EditEmployee(int id ,Employee employee);
        public void DeleteEmployee(int id);
    }
}
