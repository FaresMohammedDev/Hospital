using Hospital.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.DTOs.Treatment
{
    public record UpdateTreatmentDto
    {
        public DateTime TreatmentDateTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
