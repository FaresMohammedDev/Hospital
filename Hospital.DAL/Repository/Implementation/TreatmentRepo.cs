using Hospital.DAL.Models;
using Hospital.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Repository.Implementation
{
    public class TreatmentRepo : GenericRepo<Treatment>, ITreatmentRepo
    {
        private readonly ApplicationDbContext _context;
        public TreatmentRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Treatment>> GetAllTreatmentsWithDetailsAsync()
        {
            return await _context.Treatments
                .Include(x => x.Doctor)
                .Include(x => x.Patient).ToListAsync();
        }

        public async Task<Treatment> GetTreatmentByIdWithDetailsAsync(int id)
        {
            var treatment = await _context.Treatments
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .FirstOrDefaultAsync(x => x.Id == id);

            
            return treatment;
            
        }
    }
}
