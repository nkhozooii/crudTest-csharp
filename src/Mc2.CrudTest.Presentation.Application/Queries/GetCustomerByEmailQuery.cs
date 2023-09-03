using Mc2.CrudTest.Presentation.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Application.Queries
{
    // Customer GetCustomerByEmailQuery with Customer response
    public class GetCustomerByEmailQuery : IRequest<Customer>
    {
        public string Email { get; set; }

        public GetCustomerByEmailQuery(string email)
        {
            this.Email = email;
        }

    }
}
