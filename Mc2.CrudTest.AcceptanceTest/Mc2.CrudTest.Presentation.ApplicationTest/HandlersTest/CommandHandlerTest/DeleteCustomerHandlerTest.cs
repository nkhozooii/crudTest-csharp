using AutoMapper;
using Azure.Core;
using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.Application.Commands;
using Mc2.CrudTest.Presentation.Application.Handlers.CommandHandler;
using Mc2.CrudTest.Presentation.Core.Repositories.Command;
using Mc2.CrudTest.Presentation.Core.Repositories.Query;
using Mc2.CrudTest.Presentation.Infrastructure.Repository.Query;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTest.HandlersTest
{
    public class DeleteCustomerHandlerTest
    {
        [Theory]
        [InlineData(1, -1)]
        public async Task DeleteCustomerTest(int ValidId, int inValidId)
        {
            var moq1 = new Mock<ICustomerCommandRepository>();
            var moq2 = moq1.As<ICustomerQueryRepository>();

            moq2.Setup(m2 => m2.GetByIdAsync(ValidId))
                .ReturnsAsync(moqData.GetAll().First(p => p.Id == ValidId));

            DeleteCustomerHandler deleteCustomerHandler = new(moq1.Object, moq2.Object);

            //Act
            var result = await deleteCustomerHandler.Handle(new DeleteCustomerCommand(ValidId), CancellationToken.None);
            //Assert
            Assert.IsType<string>(result);

            //------------ByInvalidId:------------           
            //Act
            var inValidIdResult = deleteCustomerHandler.Handle(new DeleteCustomerCommand(inValidId), CancellationToken.None);
            //Assert
            _ = Assert.ThrowsAsync<ArgumentException>(() => inValidIdResult);
        }
    }
}
