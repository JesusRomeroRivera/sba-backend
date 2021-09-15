using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Resources
{
    public class SaveSpecialityTechnicalResource
    {
        [Required]
        public int SpecialityId { get; set; }
        [Required]
        public int TechnicalId { get; set; }
    }
}
