using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Models
{
    public class SpecialityTechnician
    {
        //Many to Many Relationship
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }
    }
}
