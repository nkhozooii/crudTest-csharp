using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.Application.Handlers.QueryHandlers;
using Mc2.CrudTest.Presentation.Application.Queries;
using Mc2.CrudTest.Presentation.Core.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTest.Mc2.CrudTest.Presentation.ApplicationTest.HandlersTest.QueryHandlersTest
{
    public class GetCustomerByEmailHandlerTest
    {
        [Theory]
        [InlineData("nkhozooii@gmail.com", "nkhozooii")]
        public async Task GetByIdHandleTest(string ValidEmail, string inValidEmail)
        {
            //Arrange
            var moq = new Mock<IMediator>(MockBehavior.Strict);
            moq.Setup(m => m.Send(It.IsAny<GetAllCustomerQuery>(), default))
               .ReturnsAsync(moqData.GetAll());
            GetCustomerByEmailHandler getCustomerByEmailHandler = new(moq.Object);

            //Act
            var result = await getCustomerByEmailHandler.Handle(new GetCustomerByEmailQuery(ValidEmail), CancellationToken.None);

            //Assert
            Assert.IsType<Customer>(result);
            Assert.NotNull(result);
            Assert.Equal(ValidEmail, result.Email);

            //------------ByInvalidId:------------           
            //Act
            var inValidResult = await getCustomerByEmailHandler.Handle(new GetCustomerByEmailQuery(inValidEmail), CancellationToken.None);
            //Assert            
            Assert.Null(inValidResult);
        }
    }
}
