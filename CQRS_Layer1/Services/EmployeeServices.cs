using CQRS_Layer1.Dmains;
using CQRS_Layer1.Rebos;

namespace CQRS_Layer1.Services
{
    public class EmployeeServices : IEmployee
    {

        private readonly DBContext.DBContext _db;

        public EmployeeServices(DBContext.DBContext db)
        {
            _db = db;
        }

        public void AddEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var emp = GetEmployeeById(id);
            if(emp == null)
                return;
            _db.Employees.Remove(emp);
            _db.SaveChanges();
        }

        public Employee EditEmployee(int id, Employee newemployee)
        {
            var oldemployee=GetEmployeeById(id);
            if(oldemployee == null) 
                return null;
            oldemployee.Name = newemployee.Name;
            oldemployee.Age = newemployee.Age;
            _db.SaveChanges();
            return oldemployee;
        }

        public Employee GetEmployeeById(int id)
        {
            var emp=_db.Employees.Find(id);
            return emp;

        }

        public List<Employee> GetEmployees()
        {
           var emps= _db.Employees.ToList();
            return emps;
        }
    }
}
