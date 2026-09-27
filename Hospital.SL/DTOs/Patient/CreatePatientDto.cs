using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.DTOs.Patient
{
    public record CreatePatientDto
    {
        public string Name { get; set; } = string.Empty;
        public string Illness { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
    }
}
