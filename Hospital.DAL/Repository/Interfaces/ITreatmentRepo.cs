using Hospital.DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Repository.Interfaces
{
    public interface ITreatmentRepo : IGenericRepo<Treatment>
    {
        Task<List<Treatment>> GetAllTreatmentsWithDetailsAsync();
        Task<Treatment> GetTreatmentByIdWithDetailsAsync(int id);
    }
}
