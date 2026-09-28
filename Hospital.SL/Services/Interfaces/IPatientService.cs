using Hospital.BL.Common;
using Hospital.BL.DTOs.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.Services.Interfaces
{
    public interface IPatientService
    {
        Task<ServiceResponse<List<GetPatientDto>>> GetAllPatientsAsync();
        Task<ServiceResponse<GetPatientDto>> GetPatientByIdAsync(int id);
        Task<ServiceResponse<int>> CreatePatientAsync(CreatePatientDto patientDto);
        Task<ServiceResponse<bool>> UpdatePatientAsync(UpdatePatientDto patientDto, int id);
        Task<ServiceResponse<bool>> DeletePatientAsync(int id);
    }
}
