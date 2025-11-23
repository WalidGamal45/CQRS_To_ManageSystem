using CQRS_Layer1.Dmains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Layer1.CQRS.Queries
{
    public record GetEmpQuery (int id):IRequest<Employee>;
    
}
