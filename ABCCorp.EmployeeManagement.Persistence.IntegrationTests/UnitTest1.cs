using ABCCorp.EmployeeManagement.Domain;
using ABCCorp.EmployeeManagement.Persistence.Migrations;
using ABCCorpEmployeeManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ABCCorp.EmployeeManagement.Persistence.IntegrationTests
{
    public class EmployeeManagementDatabaseContextTests
    {
        private readonly EmployeeManagementDatabaseContext _employeeManagementDatabaseContext;

        public EmployeeManagementDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<EmployeeManagementDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _employeeManagementDatabaseContext = new EmployeeManagementDatabaseContext(dbOptions);

        }

        [Fact]
        public async Task AddEmployeeRecord_SavesToDatabase()
        {
            // Arrange
            var employeeRecord = new EmployeeRecord
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Mobile = "1234567890",
                EmergencyContact = "Jane Doe",
                BloodGroup = "O+",
                ExperienceInYears = 5,
                Role = "Developer",
                Status = "Active",
                AdminVerificationStatus = "Verified"
            };

            // Act
            _employeeManagementDatabaseContext.EmployeeRecords.Add(employeeRecord);
            await _employeeManagementDatabaseContext.SaveChangesAsync();

            // Assert
            var savedRecord = await _employeeManagementDatabaseContext.EmployeeRecords.FirstOrDefaultAsync(e => e.Email == "john.doe@example.com");
            Assert.NotNull(savedRecord);
            Assert.Equal("John", savedRecord.FirstName);
            Assert.Equal("Doe", savedRecord.LastName);
        }

        [Fact]
        public async Task GetEmployeeRecord_ReturnsCorrectData()
        {
            // Arrange
            var employeeRecord = new EmployeeRecord
            {
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Mobile = "0987654321",
                EmergencyContact = "John Smith",
                BloodGroup = "A+",
                ExperienceInYears = 3,
                Role = "Tester",
                Status = "Active",
                AdminVerificationStatus = "Verified"
            };

            _employeeManagementDatabaseContext.EmployeeRecords.Add(employeeRecord);
            await _employeeManagementDatabaseContext.SaveChangesAsync();

            // Act
            var retrievedRecord = await _employeeManagementDatabaseContext.EmployeeRecords.FirstOrDefaultAsync(e => e.Email == "jane.smith@example.com");

            // Assert
            Assert.NotNull(retrievedRecord);
            Assert.Equal("Jane", retrievedRecord.FirstName);
            Assert.Equal("Smith", retrievedRecord.LastName);
        }

        [Fact]
        public async Task UpdateEmployeeRecord_UpdatesData()
        {
            // Arrange
            var employeeRecord = new EmployeeRecord
            {
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                Mobile = "1122334455",
                EmergencyContact = "Bob Johnson",
                BloodGroup = "B+",
                ExperienceInYears = 4,
                Role = "Manager",
                Status = "Active",
                AdminVerificationStatus = "Verified"
            };

            _employeeManagementDatabaseContext.EmployeeRecords.Add(employeeRecord);
            await _employeeManagementDatabaseContext.SaveChangesAsync();

            // Act
            employeeRecord.LastName = "Williams";
            _employeeManagementDatabaseContext.EmployeeRecords.Update(employeeRecord);
            await _employeeManagementDatabaseContext.SaveChangesAsync();

            // Assert
            var updatedRecord = await _employeeManagementDatabaseContext.EmployeeRecords.FirstOrDefaultAsync(e => e.Email == "alice.johnson@example.com");
            Assert.NotNull(updatedRecord);
            Assert.Equal("Williams", updatedRecord.LastName);
        }

        [Fact]
        public async Task DeleteEmployeeRecord_RemovesFromDatabase()
        {
            // Arrange
            var employeeRecord = new EmployeeRecord
            {
                FirstName = "Bob",
                LastName = "Brown",
                Email = "bob.brown@example.com",
                Mobile = "6677889900",
                EmergencyContact = "Alice Brown",
                BloodGroup = "AB+",
                ExperienceInYears = 2,
                Role = "Intern",
                Status = "Inactive",
                AdminVerificationStatus = "Pending"
            };

            _employeeManagementDatabaseContext.EmployeeRecords.Add(employeeRecord);
            await _employeeManagementDatabaseContext.SaveChangesAsync();

            // Act
            _employeeManagementDatabaseContext.EmployeeRecords.Remove(employeeRecord);
            await _employeeManagementDatabaseContext.SaveChangesAsync();

            // Assert
            var deletedRecord = await _employeeManagementDatabaseContext.EmployeeRecords.FirstOrDefaultAsync(e => e.Email == "bob.brown@example.com");
            Assert.Null(deletedRecord);
        }


    }
}