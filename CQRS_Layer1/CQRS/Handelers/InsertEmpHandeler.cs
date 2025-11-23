using CQRS_Layer1.CQRS.Commands;
using CQRS_Layer1.Dmains;
using MediatR;

namespace CQRS_Layer1.CQRS.Handelers
{
    public class InsertEmpHandeler : IRequestHandler<InsertEmpCommand, Employee>
    {
        private readonly DBContext.DBContext _dbContext;

        public InsertEmpHandeler(DBContext.DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> Handle(InsertEmpCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(request.Employee);
            await _dbContext.SaveChangesAsync();
            return request.Employee;
        }
    }
}
