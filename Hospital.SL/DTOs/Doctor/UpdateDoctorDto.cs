using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.DTOs.Doctor
{
    public record UpdateDoctorDto
    {
        public string Name { get; set; } = string.Empty;
        public double Salary { get; set; }
        public string Major { get; set; } = string.Empty;
    }
}
