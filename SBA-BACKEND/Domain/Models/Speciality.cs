using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Many to Many reverse Relationship
        public List<SpecialityTechnical> SpecialityTechnicals { get; set; }
    }
}
