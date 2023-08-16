
using Mc2.CrudTest.Presentation.Core;
using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.Repositories.Command;
using Mc2.CrudTest.Presentation.Infrastructure.Repository.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mc2.CrudTest.Presentation.Infrastructure.Repository.Command
{
    // Command Repository class for customer
    public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(CrudTestDbContext context) : base(context)
        {

        }
    }
}
