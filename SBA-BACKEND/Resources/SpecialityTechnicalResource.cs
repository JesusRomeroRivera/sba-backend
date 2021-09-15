using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Resources
{
    public class SpecialityTechnicalResource
    {
        public SpecialityResource Speciality { get; set; }
        public TechnicalResource Technical { get; set; }
    }
}
