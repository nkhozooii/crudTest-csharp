using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.Application.Handlers.QueryHandlers;
using Mc2.CrudTest.Presentation.Application.Queries;
using Mc2.CrudTest.Presentation.Core.Entities;
using MediatR;
using Moq;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTest.ApplicationTest.HandlersTest
{ 
    public class GetCustomerByIdHandlerTest
    {
        [Theory]
        [InlineData(1, -1)]
        public async Task GetByIdHandleTest(int ValidId, int inValidId)
        {
            //Arrange
            var moq = new Mock<IMediator>(MockBehavior.Strict);           
            moq.Setup(m => m.Send(It.IsAny<GetAllCustomerQuery>(), default))
               .ReturnsAsync(moqData.GetAll());
            GetCustomerByIdHandler getCustomerByIdHandler = new(moq.Object);

            //Act
            var result = await getCustomerByIdHandler.Handle(new GetCustomerByIdQuery(ValidId), CancellationToken.None);

            //Assert
            Assert.IsType<Customer>(result);
            Assert.NotNull(result);
            Assert.Equal(ValidId, result.Id);

            //------------ByInvalidId:------------           
            //Act
            var inValidResult = await getCustomerByIdHandler.Handle(new GetCustomerByIdQuery(inValidId), CancellationToken.None);

            //Assert            
            Assert.Null(inValidResult);
        }

    }
}
