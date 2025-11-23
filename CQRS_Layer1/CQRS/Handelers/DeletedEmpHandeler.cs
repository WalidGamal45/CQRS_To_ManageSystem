using CQRS_Layer1.CQRS.Commands;
using MediatR;

namespace CQRS_Layer1.CQRS.Handelers
{
    public class DeletedEmpHandeler : IRequestHandler<DeleteEmpCommand, string>
    {
        private readonly DBContext.DBContext _dbContext;

        public DeletedEmpHandeler(DBContext.DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> Handle(DeleteEmpCommand request, CancellationToken cancellationToken)
        {
            var emp = await _dbContext.Employees.FindAsync(request.id);
            if (emp == null)
                return null;
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return "Is Deleted";
        }
    }
}
