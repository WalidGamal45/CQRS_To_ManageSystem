using CQRS_Layer1.Dmains;
using MediatR;

namespace CQRS_Layer1.CQRS.Commands
{
    public record InsertEmpCommand(Employee Employee) : IRequest<Employee>;
   
}
