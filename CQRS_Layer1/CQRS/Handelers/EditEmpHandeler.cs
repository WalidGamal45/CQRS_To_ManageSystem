using CQRS_Layer1.CQRS.Commands;
using CQRS_Layer1.Dmains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Layer1.CQRS.Handelers
{
    public class EditEmpHandeler : IRequestHandler<EditEmpCommand, Employee>
    {
        private readonly DBContext.DBContext _dbContext;

        public EditEmpHandeler(DBContext.DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> Handle(EditEmpCommand request, CancellationToken cancellationToken)
        {
            var emp = await _dbContext.Employees.FindAsync(request.id);
            if (emp == null)
                return null;
            emp.Name=request.employee.Name;
            emp.Age=request.employee.Age;
            _dbContext.Update(emp);
             await _dbContext.SaveChangesAsync();
            return emp;

        }
    }
}
