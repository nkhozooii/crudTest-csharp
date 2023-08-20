using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.API.Controllers;
using Mc2.CrudTest.Presentation.Application.Handlers.QueryHandlers;
using Mc2.CrudTest.Presentation.Application.Queries;
using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.Repositories.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTest.ApplicationTest.HandlersTest
{
    public class GetAllCustomerHandlerTest
    {
        [Fact]
        public async Task GetAllHandleTest()
        {
            var moq = new Mock<ICustomerQueryRepository>();
            moq.Setup(r => r.GetAllAsync()).ReturnsAsync(moqData.GetAll());
            GetAllCustomerHandler getAllCustomerHandler = new(moq.Object);
            //Act
            var result = await getAllCustomerHandler.Handle(new GetAllCustomerQuery(), CancellationToken.None);
            //Assert
            Assert.IsType<List<Customer>>(result);
        }
    }
}
