using CQRS_Layer1.CQRS.Queries;
using CQRS_Layer1.Dmains;
using MediatR;

namespace CQRS_Layer1.CQRS.Handelers
{
    public class GetListEmpsHandeler : IRequestHandler<GetAllEmpsQuery, List<Employee>>
    {
        private readonly DBContext.DBContext _dbContext;

        public GetListEmpsHandeler(DBContext.DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> Handle(GetAllEmpsQuery request, CancellationToken cancellationToken)
        {
            var emps = _dbContext.Employees.ToList();
            return await Task.FromResult(emps);
        }
    }
}
