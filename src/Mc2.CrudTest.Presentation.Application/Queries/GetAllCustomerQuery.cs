using Mc2.CrudTest.Presentation.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Application.Queries
{
    // Customer query with List<Customer> response
    public record GetAllCustomerQuery : IRequest<List<Customer>>
    {

    }
}
