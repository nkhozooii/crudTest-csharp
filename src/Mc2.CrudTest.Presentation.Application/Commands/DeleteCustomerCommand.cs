using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Application.Commands
{
    public class DeleteCustomerCommand : IRequest<String>
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
