using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.Common;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.GetAllEmployeeRecords;
using ABCCorp.EmployeeManagement.Application.MappingProfiles;
using ABCCorp.EmployeeManagement.Application.UnitTests.Mocks;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ABCCorp.EmployeeManagement.Application.UnitTests.Features.EmployeeRecord.Queries.GetAllEmployeeRecords
{
    public class GetAllEmployeeRecordsQueryHandlerTests
    {
        private readonly Mock<IEmployeeRecordRepository> _mockEmployeeRecordRepository;
        private readonly IMapper _mapper;
        private readonly GetAllEmployeeRecordsQueryHandler _handler;

        public GetAllEmployeeRecordsQueryHandlerTests()
        {
            _mockEmployeeRecordRepository = MockEmployeeRecordRepository.GetMockEmployeeRecordRepository();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployeeRecordProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();
            _handler = new GetAllEmployeeRecordsQueryHandler(_mapper, _mockEmployeeRecordRepository.Object);
        }

        [Fact]
        public async Task Handle_ReturnsCorrectData()
        {
            // Arrange
            var query = new GetAllEmployeeRecordsQuery
            {
                FilterFirstName = "John",
                FilterLastName = "Doe",
                FilterDateCreated = null,
                FilterDateModified = null,
                SortBy = "FirstName",
                SortDirection = "asc",
                Page = 1,
                PageSize = 10
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<EmployeeRecordDetailsDto>>(result);
            Assert.Equal(2, result.Count); // Assuming the mock repository returns 2 records
        }
    }
}
