using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Illness { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; } = new HashSet<Treatment>();

    }
}
