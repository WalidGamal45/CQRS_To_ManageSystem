using CQRS_Layer1.Dmains;
using MediatR;

namespace CQRS_Layer1.CQRS.Queries
{
    public record GetAllEmpsQuery:IRequest<List<Employee>>;
    
}
