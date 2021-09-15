using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Models
{
    public class SpecialityTechnical
    {
        //Many to Many Relationship
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public int TechnicalId { get; set; }
        public Technical Technical { get; set; }
    }
}
