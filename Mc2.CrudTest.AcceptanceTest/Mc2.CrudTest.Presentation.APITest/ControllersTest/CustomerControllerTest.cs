
using Azure;
using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.API.Controllers;
using Mc2.CrudTest.Presentation.Application.Commands;
using Mc2.CrudTest.Presentation.Application.Handlers.QueryHandlers;
using Mc2.CrudTest.Presentation.Application.Queries;
using Mc2.CrudTest.Presentation.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System.Threading;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTest.APITest.ControllersTest
{
    public class CustomerControllerTest
    {

        [Fact]
        public async Task GetTest()
        {
            //Arrange
            var moq = new Mock<IMediator>();
            moq.Setup(m => m.Send(new GetAllCustomerQuery(), CancellationToken.None))
                     .ReturnsAsync(moqData.GetAll());
            CustomerController customerController = new(moq.Object);
            //Act
            var result = await customerController.Get();
            //Assert
            _ = Assert.IsType<List<Customer>>(result);

        }
        [Theory]
        [InlineData(1, -1)]
        public async Task GetByIdTest(int ValidId, int inValidId)
        {
            //Arrange
            var moq = new Mock<IMediator>();

            moq.Setup(m => m.Send(new GetCustomerByIdQuery(ValidId), CancellationToken.None))
               .ReturnsAsync(moqData.GetAll().FirstOrDefault(c => c.Id == ValidId));
            CustomerController customerController = new(moq.Object);
            //Act
            var result = await customerController.Get(ValidId);
            //Assert
             Assert.IsType<Customer>(result);          
        }


        [Theory]
        [InlineData(1, -1)]
        public async Task DeleteCustomerTest(int ValidId, int inValidId)
        {

            var moq = new Mock<IMediator>();
            //moq.Setup(m => m.Send(new DeleteCustomerCommand(ValidId), CancellationToken.None))
            //    .ReturnsAsync(moqData.GetAll().First(c => c.Id == ValidId)); ;              
            CustomerController customerController = new(moq.Object);
            //Act

            var result = await customerController.DeleteCustomer(ValidId);
            var invalidResult = await customerController.DeleteCustomer(inValidId);
            //Assert
            _ = Assert.IsType<Task<OkObjectResult>>(result);

            _ = Assert.IsType<Task<BadRequestResult>>(invalidResult);
           
        }

    }
}
