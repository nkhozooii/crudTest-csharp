using Mc2.CrudTest.Presentation.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Application.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        public DateTime CreatedDate { get; set; }

        public CreateCustomerCommand()
        {
            this.CreatedDate = DateTime.Now;         
        }
    }
}
