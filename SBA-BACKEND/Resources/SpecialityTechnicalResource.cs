using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Resources
{
    public class SpecialityTechnicianResource
    {
        public SpecialityResource Speciality { get; set; }
        public TechnicianResource Technician { get; set; }
    }
}
