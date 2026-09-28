using Hospital.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.DTOs.Treatment
{
    public record GetTreatmentDto
    {
        public int Id { get; set; }
        public DateTime TreatmentDateTime { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string Illness { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
    }
}
