using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public string DiagnosisSummary { get; set; }

        public int RoomNumber { get; set; }

        public int BedNumber { get; set; }

        public string PatientMobile { get; set; }

        public string PatientDOB { get; set; }

        public int AssignedDocId { get; set; }

        public string AssignedDocname { get; set; }

        public int PatientActive { get; set; }

        public string PrescriptionPicName { get; set; }
    }
}
