using AutoMapper.Execution;
using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.Application.Commands;
using Mc2.CrudTest.Presentation.Application.Handlers.CommandHandler;
using Mc2.CrudTest.Presentation.Application.Response;
using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.Repositories.Command;
using Moq;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTest.HandlersTest
{
    public class CreateCustomerHandlerTest
    {
        [Fact]
        public async Task CreateCustomerTest()
        {
            var moq = new Mock<ICustomerCommandRepository>();
            
            moq.Setup(c => c.AddAsync(It.IsAny<Customer>())).ReturnsAsync((Customer customer) => {
                moqData.GetAll().Add(customer);
                return customer;
            });
            CreateCustomerHandler createCustomerHandler = new(moq.Object);

            //Act
            var result = await createCustomerHandler.Handle(new CreateCustomerCommand
            {
                FirstName = "Reza",
                LastName = "Khozooii",
                Email = "r.kh@gmail.com",
                BankAccountNumber = "387640987",
                DateOfBirth = new DateTime(1988, 06, 11),
                PhoneNumber = "+4312345678"
            }, default);
                
            //Assert
            Assert.IsType<CustomerResponse>(result);
        }
    }
}
