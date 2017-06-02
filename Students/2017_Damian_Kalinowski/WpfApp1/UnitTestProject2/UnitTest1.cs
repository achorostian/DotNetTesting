using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1.ViewModels;
using WpfApp1.Models;
using WpfApp1.Services;
using System.Collections.Generic;
using Moq;
using System.Threading.Tasks;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitialListIsNotNull()
        {
            // Arrange
            var viewModel = new MainWindowViewModel();

            // Act
            var collection = viewModel.Persons;

            // Assert
            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void AddPersonTest()
        {
            // Arrange
            var viewModel = new MainWindowViewModel();

            // Act
            viewModel.Name = "Jan";
            viewModel.Surname = "Kowalski";
            viewModel.Age = 38;
            viewModel.AddPerson.Execute(null);
            var collection = viewModel.Persons;

            // Assert
            Assert.IsNotNull(collection.Find(person => 
                person.Name == "Jan" && 
                person.Surname == "Kowalski" && 
                person.Age == 38));
        }

        [TestMethod]
        public void RemovePersonAcceptedTest()
        {
            // Arrange
            var service = new Mock<IDialogBoxService>();
            service.Setup(s => s.AreYouSureQuestion(It.IsAny<string>())).Returns(true);
            var viewModel = new MainWindowViewModel(service.Object);
            var person = new Person { Name = "Jan", Surname = "Kowalski", Age = 38 };
            viewModel.Persons = new List<Person> { person };

            // Act
            viewModel.Name = "Jan";
            viewModel.Surname = "Kowalski";
            viewModel.Age = 38;
            viewModel.DeletePerson.Execute(null);
            var collection = viewModel.Persons;

            // Assert
            CollectionAssert.DoesNotContain(collection, person);
        }

        [TestMethod]
        public void RemovePersonCancellationTest()
        {
            // Arrange
            var service = new Mock<IDialogBoxService>();
            service.Setup(s => s.AreYouSureQuestion(It.IsAny<string>())).Returns(false);
            var viewModel = new MainWindowViewModel(service.Object);
            var person = new Person { Name = "Jan", Surname = "Kowalski", Age = 38 };
            viewModel.Persons = new List<Person> { person };

            // Act
            viewModel.Name = "Jan";
            viewModel.Surname = "Kowalski";
            viewModel.Age = 38;
            viewModel.DeletePerson.Execute(null);
            var collection = viewModel.Persons;

            // Assert
            CollectionAssert.Contains(collection, person);
        }

        [TestMethod]
        public void FeedPersonTest()
        {
            // Arrange
            var person1 = new Person { Name = "ExampleName", Surname = "ExampleSurname", Age = 99 };
            var person2 = new Person { Name = "SomeName", Surname = "SomeSurname", Age = 89 };

            var service = new Mock<IWebApiService>();
            service.Setup(s => s.GetPeopleAsync()).Returns(Task.FromResult(new List<Person> { person1, person2 }));
            var viewModel = new MainWindowViewModel(service.Object);

            // Act
            viewModel.FeedPerson.Execute(null);
            var collection = viewModel.Persons;

            // Assert
            Assert.AreEqual(2, collection.Count);
            CollectionAssert.Contains(collection, person1);
            CollectionAssert.Contains(collection, person2);
        }
    }
}
