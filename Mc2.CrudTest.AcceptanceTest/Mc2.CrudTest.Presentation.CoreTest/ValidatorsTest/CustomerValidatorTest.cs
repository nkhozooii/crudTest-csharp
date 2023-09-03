using FluentValidation.TestHelper;

using Mc2.CrudTest.Presentation.Core.DefineAttributes;
using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.Validators;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mc2.CrudTest.AcceptanceTest.Mc2.CrudTest.Presentation.CoreTest.ValidatorsTest
{

    public class CustomerValidatorTest
    {
        private CustomerValidator validator;

        public CustomerValidatorTest()
        {
            validator = new CustomerValidator();
        }

        [Fact]
        public void Should_have_error_when_FirstName_is_null()
        {
            var model = new Customer { FirstName = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.FirstName);
        }
        [Fact]
        public void Should_not_have_error_when_FirstName_is_specified()
        {
            var model = new Customer { FirstName = "Narges" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(c => c.FirstName);
        }
        [Fact]
        public void Should_have_error_when_LastName_is_null()
        {
            var model = new Customer { LastName = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.LastName);
        }
        [Fact]
        public void Should_not_have_error_when_LastName_is_specified()
        {
            var model = new Customer { LastName = "Khozooii" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(c => c.LastName);
        }
        [Fact]
        public void Invalid_email_address_test()
        {
            //Arrange
            var badEmail = "1234_)(";
            var model = new Customer { Email = badEmail };

            //Act
            var result = validator.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(c => c.Email);          
        }
        [Fact]
        public void Valid_email_addresses_test()
        {
            //Arrange
            var Email = "nkhozooii@gmail.com";
            var model = new Customer { Email = Email };

            //Act
            var result = validator.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(c => c.Email);
        }
        [Fact]
        public void Should_have_error_when_Email_is_null()
        {
            var model = new Customer { Email = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Email);
        }
        [Fact]
        public void Should_not_have_error_when_Email_is_specified()
        {
            var model = new Customer { Email = "nkhozooii@gmail.com" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(c => c.Email);
        }
        [Fact]
        public void Should_not_have_error_when_DateOfBirth_is_null()
        {
            var model = new Customer { DateOfBirth = null };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(c => c.DateOfBirth);
        }
        [Fact]
        public void Invalid_phoneNumber_test()
        {
            //Arrange
            var badPhoneNumber = "1234_)(";
            var model = new Customer { PhoneNumber = badPhoneNumber };

            //Act
            var result = validator.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(c => c.PhoneNumber);
        }
        [Fact]
        public void Valid_phoneNumber_test()
        {
            //Arrange
            var PhoneNumber = "+1-650-318-1051";
            var model = new Customer { PhoneNumber = PhoneNumber };

            //Act
            var result = validator.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(c => c.PhoneNumber);
        }
        [Fact]
        public void Invalid_BankAccountNumber_test()
        {
            //Arrange
            var badBankAccountNumber = "1234_)(";
            var model = new Customer { BankAccountNumber = badBankAccountNumber };

            //Act
            var result = validator.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(c => c.BankAccountNumber);
        }
        [Fact]
        public void Valid_BankAccountNumber_test()
        {
            //Arrange
            var BankAccountNumber = "635802010014976";
            var model = new Customer { BankAccountNumber = BankAccountNumber };

            //Act
            var result = validator.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(c => c.BankAccountNumber);
        }
    }
}
