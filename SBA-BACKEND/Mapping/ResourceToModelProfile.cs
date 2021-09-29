using AutoMapper;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCustomerResource, Customer>();
            CreateMap<SaveDistrictResource, District>();
            CreateMap<SaveOpinionResource, Opinion>();
            CreateMap<SaveReportResource, Report>();
            CreateMap<SaveSpecialityResource, Speciality>();
            CreateMap<SaveSpecialityTechnicianResource, SpecialityTechnician>();
            CreateMap<SaveTechnicianResource, Technician>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
