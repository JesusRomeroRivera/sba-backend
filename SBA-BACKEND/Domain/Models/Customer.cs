using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Models
{
    public class Customer : User
    {

        //One to Many Reverse Relationship
        public IList<Opinion> Opinions { get; set; } = new List<Opinion>();
        //One to Many Reverse Relationship
        public IList<Report> Reports { get; set; } = new List<Report>();
    }
}
