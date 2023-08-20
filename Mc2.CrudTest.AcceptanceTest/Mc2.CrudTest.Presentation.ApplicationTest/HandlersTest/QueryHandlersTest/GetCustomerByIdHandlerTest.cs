using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.API.Controllers;
using Mc2.CrudTest.Presentation.Application.Handlers.QueryHandlers;
using Mc2.CrudTest.Presentation.Application.Queries;
using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.Repositories.Query;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTest.ApplicationTest.HandlersTest
{ 
    public class GetCustomerByIdHandlerTest
    {
        //[Theory]
        //[InlineData(1, -1)]
        //public async Task GetByIdHandleTest(int ValidId, int inValidId)
        //{
        //    var moq = new Mock<IMediator>();
        //    moq.Setup(m => m.Send(new GetCustomerByIdQuery(ValidId), CancellationToken.None))
        //        .ReturnsAsync(moqData.GetAll().First(p => p.Id == ValidId));
        //    GetCustomerByIdHandler getCustomerByIdHandler = new(moq.Object);
        //    //Act
        //    var result = await getCustomerByIdHandler.Handle(new GetCustomerByIdQuery(ValidId), CancellationToken.None);
        //    //Assert
        //    Assert.IsType<Customer>(result);

        //    //-------------------------------------

        //    moq.Setup(m => m.Send(new GetCustomerByIdQuery(inValidId), CancellationToken.None))
        //         .ReturnsAsync(moqData.GetAll().First(p => p.Id == inValidId));
        //    getCustomerByIdHandler = new(moq.Object);
        //    //Act
        //    var inValidIdResult = await getCustomerByIdHandler.Handle(new GetCustomerByIdQuery(inValidId), CancellationToken.None);
        //    //Assert
        //    Assert.IsType < null > (inValidIdResult);
        //}


        //  }


    }
}
