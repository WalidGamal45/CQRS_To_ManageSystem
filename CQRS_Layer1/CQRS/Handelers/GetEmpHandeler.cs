using CQRS_Layer1.CQRS.Queries;
using CQRS_Layer1.Dmains;
using MediatR;

namespace CQRS_Layer1.CQRS.Handelers
{
    public class GetEmpHandeler : IRequestHandler<GetEmpQuery, Employee>
    {
        private readonly DBContext.DBContext _dbContext;
        public GetEmpHandeler(DBContext.DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> Handle(GetEmpQuery request, CancellationToken cancellationToken)
        {
            var emp = await _dbContext.Employees.FindAsync(request.id);
            if (emp == null)
                return null;
            return await Task.FromResult(emp);
        }
    }
}
