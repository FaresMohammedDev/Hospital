using Hospital.BL.Common;
using Hospital.BL.DTOs.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.Services.Interfaces
{
    public interface ITreatmentService
    {
        Task<ServiceResponse<List<GetTreatmentDto>>> GetAllTreatmentsAsync();
        Task<ServiceResponse<GetTreatmentDto>> GetTreatmentByIdAsync(int id);
        Task<ServiceResponse<int>> CreateTreatmentAsync(CreateTreatmentDto treatmentDto);
        Task<ServiceResponse<bool>> UpdateTreatmentAsync(UpdateTreatmentDto treatmentDto, int id);
        Task<ServiceResponse<bool>> DeleteTreatmentAsync(int id);
    }
}
