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
    public class ReportServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoReportFoundReturnsReportNotFoundResponse()
        {
            // Arrange
            var mockReportRepository = GetDefaultIReportRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var reportId = 1;
            mockReportRepository.Setup(r => r.FindById(reportId))
                .Returns(Task.FromResult<Report>(null));

            var service = new ReportService(mockReportRepository.Object, mockUnitOfWork.Object);

            // Act
            ReportResponse result = await service.GetByIdAsync(reportId);
            var message = result.Message;

            // Assert
            message.Should().Be("Report not found");
        }

        [Test]
        public async Task GetByIdAsyncWhenReportFoundReturnsSuccess()
        {
            // Arrange
            var mockReportRepository = GetDefaultIReportRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var reportId = 1;
            Report r = new()
            {
                Id = 1,
                Description = "Me quemó la casa"
            };
            mockReportRepository.Setup(r => r.FindById(reportId))
                .Returns(Task.FromResult<Report>(r));

            var service = new ReportService(mockReportRepository.Object, mockUnitOfWork.Object);

            // Act
            ReportResponse result = await service.GetByIdAsync(reportId);
            var success = result.Success;

            // Assert
            success.Should().Be(true);
        }

        private Mock<IReportRepository> GetDefaultIReportRepositoryInstance()
        {
            return new Mock<IReportRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
