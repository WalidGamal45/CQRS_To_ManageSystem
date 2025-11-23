using CQRS_Layer1.Dmains;
using MediatR;

namespace CQRS_Layer1.CQRS.Commands
{
    public record EditEmpCommand(int id, Employee employee) : IRequest<Employee>;

}
