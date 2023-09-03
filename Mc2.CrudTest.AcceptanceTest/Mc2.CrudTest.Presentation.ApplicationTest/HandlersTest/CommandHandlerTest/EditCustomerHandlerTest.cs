using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.Application.Commands;
using Mc2.CrudTest.Presentation.Application.Handlers.CommandHandler;
using Mc2.CrudTest.Presentation.Application.Response;
using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.Repositories.Command;
using Mc2.CrudTest.Presentation.Core.Repositories.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTest.Mc2.CrudTest.Presentation.ApplicationTest.HandlersTest.CommandHandlerTest
{
    public class EditCustomerHandlerTest
    {
        [Theory]
        [InlineData(1, -1)]
        public async Task EditCustomerTest(int ValidId, int inValidId)
        {
            var moq1 = new Mock<ICustomerCommandRepository>();
            var moq2 = moq1.As<ICustomerQueryRepository>();
            moq1.Setup(c => c.UpdateAsync(It.IsAny<Customer>()));
            moq2.Setup(m2 => m2.GetByIdAsync(ValidId))
               .ReturnsAsync(moqData.GetAll().First(p => p.Id == ValidId));

            EditCustomerHandler editCustomerHandler = new(moq1.Object,moq2.Object);
            //Act
            var result = await editCustomerHandler.Handle(new EditCustomerCommand
                {
                    Id = ValidId,
                    FirstName = "Reza",
                    LastName = "Khozooii",
                    Email = "r.kh@gmail.com",
                    BankAccountNumber = "387640987",
                    DateOfBirth = new DateTime(1988, 06, 11),
                    PhoneNumber = "+4312345678"
                }, default);
            //Assert
            Assert.IsType<CustomerResponse>(result);
            Assert.NotNull(result);

            //------------ByInvalidId:------------           

            var invalidResult = await editCustomerHandler.Handle(new EditCustomerCommand
            {
                Id = inValidId,
                FirstName = "Reza",
                LastName = "Khozooii",
                Email = "r.kh@gmail.com",
                BankAccountNumber = "387640987",
                DateOfBirth = new DateTime(1988, 06, 11),
                PhoneNumber = "+4312345678"
            }, default);
            //Assert
            Assert.Null(invalidResult);
                      
        }            

    }
}
