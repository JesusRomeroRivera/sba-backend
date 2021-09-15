using AutoMapper;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Customer, CustomerResource>();
            CreateMap<District, DistrictResource>();
            CreateMap<Opinion, OpinionResource>();
            CreateMap<Report, ReportResource>();
            CreateMap<Speciality, SpecialityResource>();
            CreateMap<SpecialityTechnical, SpecialityTechnicalResource>();
            CreateMap<Technical, TechnicalResource>();
            CreateMap<User, UserResource>();
        }
    }
}
