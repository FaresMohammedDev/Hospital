using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Salary { get; set; }
        public string Major { get; set; } = string.Empty;
        public IEnumerable<Treatment> Treatments { get; set; } = new HashSet<Treatment>();
    }
}
