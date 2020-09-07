using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdenClinic.Models
{
    public class PrescriptionsResult
    {
        public Guid PrescriptionID { get; set; }
        public Guid PrescriptionDetailID { get; set; }
        public Guid ReservationID { get; set; }
        public string PatientName { get; set; }
        public string Notes { get; set; }
        public string DrugName { get; set; }
        public double? Dosage { get; set; }
        public byte? Count { get; set; }
        public byte? DaysCount { get; set; }
        public DateTime? ReservationDate { get; set; }

        public string DoctorName { get; set; }
        //public int UserID { get; set; }
    }
}