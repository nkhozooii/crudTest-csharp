﻿using FluentValidation.Results;
using Mc2.CrudTest.Presentation.Application.Commands;
using Mc2.CrudTest.Presentation.Application.Mapper;
using Mc2.CrudTest.Presentation.Application.Response;
using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.Repositories.Command;
using Mc2.CrudTest.Presentation.Core.Repositories.Query;
using Mc2.CrudTest.Presentation.Core.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Application.Handlers.CommandHandler
{
    public class EditCustomerHandler : IRequestHandler<EditCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        public EditCustomerHandler(ICustomerCommandRepository customerRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _customerCommandRepository = customerRepository;
            _customerQueryRepository = customerQueryRepository;
        }
        public async Task<CustomerResponse> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
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
                customerResponse.Id =request.Id;
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
                try
                {
                    await _customerCommandRepository.UpdateAsync(customerEntity);
                }
                catch (Exception exp)
                {
                    throw new ApplicationException(exp.Message);
                }

                var modifiedCustomer = await _customerQueryRepository.GetByIdAsync(request.Id);
                var customerResponse = CustomerMapper.Mapper.Map<CustomerResponse>(modifiedCustomer);

                return customerResponse;
            }
        }
    }
}
