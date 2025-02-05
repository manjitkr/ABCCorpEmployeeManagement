using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCCorp.EmployeeManagement.Domain;

namespace ABCCorp.EmployeeManagement.Application.UnitTests.Mocks
{
    class MockEmployeeRecordRepository
    {
        public static Mock<IEmployeeRecordRepository> GetMockEmployeeRecordRepository()
        {
            var employeeRecords = new List<EmployeeRecord>
            {
                new EmployeeRecord
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com",
                    Mobile = "1234567890",
                    EmergencyContact = "1234567890",
                    BloodGroup = "A+",
                    Role = "Developer",
                    Status = "Active",
                    AdminVerificationStatus = "PendingVerification",
                    DateCreated = new DateTime(2021, 1, 1),
                    DateModified = new DateTime(2021, 1, 1)
                },
                new EmployeeRecord
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email  = "janedoe@example.com",
                    Mobile = "9876543210",
                    BloodGroup = "A+",
                    Role = "Developer",
                    Status = "Active",                  
                    AdminVerificationStatus = "Verified",
                    DateCreated = new DateTime(2021, 1, 1),
                    DateModified = new DateTime(2021, 1, 1)
                }
            };
            var mockEmployeeRecordRepository = new Mock<IEmployeeRecordRepository>();
            mockEmployeeRecordRepository.Setup(repo => repo.GetAll("John","Doe",null,null,"FirstName","asc",1,10)).ReturnsAsync(employeeRecords);
            mockEmployeeRecordRepository.Setup(repo => repo.AddAsync(It.IsAny<EmployeeRecord>())).ReturnsAsync((EmployeeRecord employeeRecord) =>
            {
                employeeRecord.Id = employeeRecords.Max(x => x.Id) + 1;
                employeeRecords.Add(employeeRecord);
                return employeeRecord;
            });
            mockEmployeeRecordRepository.Setup(repo => repo.UpdateAsync(It.IsAny<EmployeeRecord>())).Callback((EmployeeRecord employeeRecord) =>
            {
                var index = employeeRecords.FindIndex(x => x.Id == employeeRecord.Id);
                if (index >= 0)
                {
                    employeeRecords[index] = employeeRecord;
                }
            });
            mockEmployeeRecordRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => employeeRecords.FirstOrDefault(x => x.Id == id));
            return mockEmployeeRecordRepository;
        }
    }
}
