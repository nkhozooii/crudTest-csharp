using Mc2.CrudTest.Presentation.Core.DefineAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTest.CoreTest.DefineAttributesTest
{
    public class PhoneNumberAttributeTest
    {
        private readonly PhoneNumberAttribute _subjectUnderTest;

        public PhoneNumberAttributeTest()
        {
            _subjectUnderTest = new PhoneNumberAttribute();
        }

        [Fact]
        public void GivenNull_WhenValidate_ThenIsValid()
        {
            Assert.True(_subjectUnderTest.IsValid(null));
        }

        [Fact]
        public void GivenEmptyString_WhenValidate_ThenIsValid()
        {
            Assert.True(_subjectUnderTest.IsValid(string.Empty));
        }

        [InlineData("+4527122799")]
        [InlineData("6503181051")]
        [InlineData("+16503181051")]
        [InlineData("1-650-318-1051")]
        [InlineData("+1-650-318-1051")]
        [InlineData("+1650-318-1051")]
        //[InlineData("invalidPhone")]
        [Theory]
        public void GivenValidPhoneNumber_WhenValidate_ThenIsValid(string phoneNumberString)
        {
            Assert.True(_subjectUnderTest.IsValid(phoneNumberString));
        }

        [InlineData("123")]
        [InlineData("foo")]
        [Theory]
        public void GivenInValidPhoneNumber_WhenValidate_ThenIsNotValid(string phoneNumberString)
        {
            Assert.False(_subjectUnderTest.IsValid(phoneNumberString));
        }
    }
}
