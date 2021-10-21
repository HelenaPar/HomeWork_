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

            var moqReposytory = new Mock<IRepository>();
            moqReposytory.Setup(r => r.EditAll(It.IsAny<Student>())).Returns(true);
            var commandAdd = new AddCommand(moqReposytory.Object, new string[] { "german", "derem", "men", "35" });
            var commandEdit = new EditCommand(moqReposytory.Object, new string[] {"1", "German", "Der", "men", "35" });

            //Act

            var add = commandAdd.Execute();
            var result = commandEdit.Execute();

            //Assert

            Assert.Equal("Запись успешно изменена!", result);
            moqReposytory.Verify(r => r.EditAll(It.IsAny<Student>()), Times.Once());
            moqReposytory.Verify(r => r.EditAll(
                It.Is<Student>(s =>
                s.id == 1 &&
                s.name == "German" &&
                s.surname == "Der" &&
                s.gender == "men" &&
                s.age == 35)));
        }
    }
}
