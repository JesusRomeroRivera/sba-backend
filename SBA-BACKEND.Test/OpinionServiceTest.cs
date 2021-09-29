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
    public class OpinionServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoOpinionFoundReturnsOpinionNotFoundResponse()
        {
            // Arrange
            var mockOpinionRepository = GetDefaultIOpinionRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var opinionId = 1;
            mockOpinionRepository.Setup(r => r.FindById(opinionId))
                .Returns(Task.FromResult<Opinion>(null));

            var service = new OpinionService(mockOpinionRepository.Object, mockUnitOfWork.Object);

            // Act
            OpinionResponse result = await service.GetByIdAsync(opinionId);
            var message = result.Message;

            // Assert
            message.Should().Be("Opinion not found");
        }

        [Test]
        public async Task GetByIdAsyncWhenOpinionFoundReturnsSuccess()
        {
            // Arrange
            var mockOpinionRepository = GetDefaultIOpinionRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var opinionId = 1;
            Opinion o = new()
            {
                Id = 1,
                Stars = 5
            };
            mockOpinionRepository.Setup(r => r.FindById(opinionId))
                .Returns(Task.FromResult<Opinion>(o));
            var service = new OpinionService(mockOpinionRepository.Object, mockUnitOfWork.Object);

            // Act
            OpinionResponse result = await service.GetByIdAsync(opinionId);
            var success = result.Success;

            // Assert
            success.Should().Be(true);
        }

        private Mock<IOpinionRepository> GetDefaultIOpinionRepositoryInstance()
        {
            return new Mock<IOpinionRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
