using Mc2.CrudTest.Presentation.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Application.Queries
{
    // Customer GetCustomerByIdQuery with Customer response
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; private set; }

        public GetCustomerByIdQuery(int Id)
        {
            this.Id = Id;
        }

    }
}
