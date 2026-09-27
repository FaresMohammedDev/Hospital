using Hospital.BL.Common;
using Hospital.BL.DTOs.Doctor;
using Hospital.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<ServiceResponse<List<GetDoctorDto>>> GetAllDoctorsAsync();
        Task<ServiceResponse<GetDoctorDto>> GetDoctorByIdAsync(int id);
        Task<ServiceResponse<int>> CreateDoctorAsync(CreateDoctorDto doctorDto);
        Task<ServiceResponse<bool>> UpdateDoctorAsync(UpdateDoctorDto doctorDto, int id);
        Task<ServiceResponse<bool>> DeleteDoctorAsync(int id);
    }
}
