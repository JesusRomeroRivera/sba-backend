using NUnit.Framework;
using Moq;
using FluentAssertions;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;
using SBA_BACKEND.Domain.Persistence.Repositories;
using SBA_BACKEND.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SBA_BACKEND.Test
{
    public class CustomerServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoCustomerFoundReturnsCustomerNotFoundResponse()
        {
            // Arrange
            var mockCustomerRepository = GetDefaultICustomerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var customerId = 1;
            mockCustomerRepository.Setup(r => r.FindById(customerId))
                .Returns(Task.FromResult<Customer>(null));

            var service = new CustomerService(mockCustomerRepository.Object, mockUnitOfWork.Object);

            // Act
            CustomerResponse result = await service.GetByIdAsync(customerId);
            var message = result.Message;

            // Assert
            message.Should().Be("Customer not found");
        }

        [Test]
        public async Task GetByIdAsyncWhenCustomerFoundReturnsSuccess()
        {
            // Arrange
            var mockCustomerRepository = GetDefaultICustomerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var customerId = 1;
            Customer c = new()
            {
                Id = 1,
                Name = "Pepe"
            };

            mockCustomerRepository.Setup(r => r.FindById(customerId))
                .Returns(Task.FromResult<Customer>(c));
            var service = new CustomerService(mockCustomerRepository.Object, mockUnitOfWork.Object);

            // Act
            CustomerResponse result = await service.GetByIdAsync(customerId);
            var success = result.Success;
            
            // Assert
            success.Should().Be(true);
        }

        private Mock<ICustomerRepository> GetDefaultICustomerRepositoryInstance()
        {
            return new Mock<ICustomerRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
