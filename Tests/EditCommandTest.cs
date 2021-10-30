using ConsoleApp1;
using ConsoleApp1.Command;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentConsoleApp_Test
{
    public class EditCommandTest
    {
        [Fact]
        public void Execute_StudentsParameters_StudentRecordChanged()
        {
            //Arrange

            var moqIRepisitory = new Mock<IRepository>();
            moqIRepisitory.Setup(r => r.EditAll(It.IsAny<Student>())).Returns(true);
            var commandAdd = new AddCommand(moqIRepisitory.Object, new string[] { "german", "derem", "men", "35" });
            var commandEdit = new EditCommand(moqIRepisitory.Object, new string[] {"1", "German", "Der", "men", "35" });

            //Act

            var result = commandEdit.Execute();

            //Assert

            Assert.Equal("Запись успешно изменена!", result);
            moqIRepisitory.Verify(r => r.EditAll(It.IsAny<Student>()), Times.Once());
            moqIRepisitory.Verify(r => r.EditAll(
                It.Is<Student>(s =>
                s.id == 1 &&
                s.name == "German" &&
                s.surname == "Der" &&
                s.gender == "men" &&
                s.age == 35)));
        }
    }
}
