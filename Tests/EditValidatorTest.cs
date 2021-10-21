using ConsoleApp1.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentConsoleApp_Test
{
    public class EditValidatorTest
    {
        [Fact]
        public void Validate_IdUncorrect_False()
        {
            //Arrange

            var validator = new EditValidator(new[] { "n", "german", "der", "men", "35" });

            //Act

            var res = validator.Validate();

            //Assert

            Assert.False(false);
            Assert.Equal("Wrong id!\n", validator.ErrorMessage);
        }
        [Fact]
        public void Validate_NameContainsNumber_False()
        {
            //Arrange

            var validator = new EditValidator(new[] { "1", "german67", "der", "men", "35" });

            //Act

            var res = validator.Validate();

            //Assert

            Assert.False(false);
            Assert.Equal("Wrong name!\n", validator.ErrorMessage);
        }
        [Fact]
        public void Validate_SurnameContainsMoreThan50Letters_False()
        {
            //Arrange

            var validator = new EditValidator(new[] { "1", "german", "derrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr", "men", "35" });

            //Act

            var res = validator.Validate();

            //Assert

            Assert.False(false);
            Assert.Equal("Wrong surname!\n", validator.ErrorMessage);
        }
        [Fact]
        public void Validate_AgeIsLessThanItShouldBe_False()
        {
            //Arrange

            var validator = new EditValidator(new[] { "1", "german", "der", "men", "17" });

            //Act

            var res = validator.Validate();

            //Assert

            Assert.False(false);
            Assert.Equal("Wrong age!\n", validator.ErrorMessage);
        }
        [Fact]
        public void Validate_AgeIsMoreThanItShouldBe_False()
        {
            //Arrange

            var validator = new EditValidator(new[] { "1", "german", "der", "men", "101" });

            //Act

            var res = validator.Validate();

            //Assert

            Assert.False(false);
            Assert.Equal("Wrong age!\n", validator.ErrorMessage);
        }
        [Fact]
        public void Validate_GenderIsWrong_False()
        {
            //Arrange

            var validator = new EditValidator(new[] { "1", "german", "der", "rtrtyrty", "35" });

            //Act

            var res = validator.Validate();

            //Assert

            Assert.False(false);
            Assert.Equal("Wrong gender!\n", validator.ErrorMessage);
        }
    }
}
