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
    public class SpecialityServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoSpecialityFoundReturnsSpecialityNotFoundResponse()
        {
            // Arrange
            var mockSpecialityRepository = GetDefaultISpecialityRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var specialityId = 1;
            mockSpecialityRepository.Setup(r => r.FindById(specialityId))
                .Returns(Task.FromResult<Speciality>(null));

            var service = new SpecialityService(mockSpecialityRepository.Object, mockUnitOfWork.Object);

            // Act
            SpecialityResponse result = await service.GetByIdAsync(specialityId);
            var message = result.Message;

            // Assert
            message.Should().Be("Speciality not found");
        }

        [Test]
        public async Task GetByIdAsyncWhenSpecialityFoundReturnsSpecialityNotFoundResponse()
        {
            // Arrange
            var mockSpecialityRepository = GetDefaultISpecialityRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var specialityId = 1;
            Speciality s = new()
            {
                Id = 1,
                Name = "Gasfitero"
            };
            mockSpecialityRepository.Setup(r => r.FindById(specialityId))
                .Returns(Task.FromResult<Speciality>(s));

            var service = new SpecialityService(mockSpecialityRepository.Object, mockUnitOfWork.Object);

            // Act
            SpecialityResponse result = await service.GetByIdAsync(specialityId);
            var success = result.Success;

            // Assert
            success.Should().Be(true);
        }

        private Mock<ISpecialityRepository> GetDefaultISpecialityRepositoryInstance()
        {
            return new Mock<ISpecialityRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
