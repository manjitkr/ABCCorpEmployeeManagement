using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Commands.CreateEmployeeRecord;
using ABCCorp.EmployeeManagement.Application.Features.EmployeeRecord.Queries.Common;
using ABCCorp.EmployeeManagement.Domain;
using AutoMapper;

namespace ABCCorp.EmployeeManagement.Application.MappingProfiles
{
    public class EmployeeRecordProfile: Profile
    {
        public EmployeeRecordProfile()
        {
                CreateMap<EmployeeRecordDetailsDto, EmployeeRecord>().ReverseMap();
                CreateMap<CreateEmployeeRecordCommand, EmployeeRecord>();
        }

    }
}
