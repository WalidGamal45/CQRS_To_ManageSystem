using MediatR;

namespace CQRS_Layer1.CQRS.Commands
{
    public record DeleteEmpCommand (int id) : IRequest<string>;

}
