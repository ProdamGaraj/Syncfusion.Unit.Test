using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Example.BusinessLogic;
using Example.DataAccess;
using Example.DataRepository;

namespace Example.Tests.TestMethods
{
    public class CustomerTestBL
    {
        private Mock<IEntityRepository<Customer>> customerRepository;
        private List<Customer> customers;
        [SetUp]
        public void Setup()
        {
            //Set up the mock
            customerRepository = new Mock<IEntityRepository<Customer>>();
            customers = new List<Customer>();
            customers.Add(new Customer() { Id = 1, FirstName = "cus1", IsDeleted = false });
            customers.Add(new Customer() { Id = 2, FirstName = "cus2", IsDeleted = true });
            customers.Add(new Customer() { Id = 3, FirstName = "cus3", IsDeleted = false });
        }

        [Test]
        public void TestGetActiveRecords()
        {
            //Act
            customerRepository.Setup(a => a.GetAllQueryable()).Returns(customers.AsQueryable());

            //Arrange
            var customerService = new CustomerService(customerRepository.Object);
            var customersList = customerService.GetActiveCustomers();

            //Arrest
            Assert.IsTrue(customersList.Count == 2);
            Assert.IsTrue(customersList.All(s => s.IsDeleted == false));
        }
    }
}
