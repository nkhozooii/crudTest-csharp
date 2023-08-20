
using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.API.Controllers;
using Mc2.CrudTest.Presentation.Application.Queries;
using Mc2.CrudTest.Presentation.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Mc2.CrudTest.Presentation.APITest.ControllersTest
{
    public class CustomerControllerTest
    {
        moqData _moqdata;
        public CustomerControllerTest()
        {
            _moqdata = new moqData();
        }
        
        [Fact]
        public void GetTest()
        {
            //Arrange

            var moq = new Mock<IMediator>();
            moq.Setup(i => i.Send(It.IsAny<GetAllCustomerQuery>(), It.IsAny<System.Threading.CancellationToken>()))
                     .ReturnsAsync(_moqdata.GetAll());
            CustomerController customerController = new(moq.Object);

            //Act

            var result = customerController.Get();

            //Assert
            //Assert.IsType<ProducesResponseType>(result);
            //var list = result as ProducesResponseTypeAttribute;
            //Assert.IsType<List<Customer>>(list.Value);
        }
    }
}
