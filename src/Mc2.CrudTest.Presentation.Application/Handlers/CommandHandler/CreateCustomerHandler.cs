using Azure;
using FluentValidation.Results;
using Mc2.CrudTest.Presentation.Application.Commands;
using Mc2.CrudTest.Presentation.Application.Mapper;
using Mc2.CrudTest.Presentation.Application.Response;
using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.Repositories.Command;
using Mc2.CrudTest.Presentation.Core.Validators;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Application.Handlers.CommandHandler
{
    // Customer create command handler with CustomerResponse as output
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        public CreateCustomerHandler(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }
        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = CustomerMapper.Mapper.Map<Customer>(request);

            if (customerEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            CustomerValidator customerValidator = new();
            List<string> ValidationMessages = new List<string>();
            var validationResult = customerValidator.Validate(customerEntity);
            if (!validationResult.IsValid)
            {
                var customerResponse = CustomerMapper.Mapper.Map<CustomerResponse>(customerEntity);
                customerResponse.Id = 0;
                customerResponse.IsValid = false;
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                customerResponse.ValidationMessages = ValidationMessages;
                 return customerResponse;
            }
            else
            {

                var newCustomer = await _customerCommandRepository.AddAsync(customerEntity);
                var customerResponse = CustomerMapper.Mapper.Map<CustomerResponse>(newCustomer);
                return customerResponse;
            }

        }
    }
}
