using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Doctor
    {
        public int DocId { get; set; }

        public string DocName { get; set; }

        public string DocField { get; set; }

        public string DocMobile { get; set; }

        public string DocEmail { get; set; }

        public string DocPassword { get; set; }

        public string DateOfJoining { get; set; }

        public string DocPicName { get; set; }
    }
}
