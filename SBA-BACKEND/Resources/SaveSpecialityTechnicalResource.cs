using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Resources
{
    public class SaveSpecialityTechnicianResource
    {
        [Required]
        public int SpecialityId { get; set; }
        [Required]
        public int TechnicianId { get; set; }
    }
}
