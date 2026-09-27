using Hospital.BL.Common;
using Hospital.BL.DTOs.Doctor;
using Hospital.BL.Services.Interfaces;
using Hospital.DAL.Models;
using Hospital.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _repo;
        public DoctorService(IDoctorRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public async Task<ServiceResponse<int>> CreateDoctorAsync(CreateDoctorDto doctorDto)
        {
            var doctor = new Doctor()
            {
                Name = doctorDto.Name,
                Major = doctorDto.Major,
                Salary = doctorDto.Salary
            };

            await _repo.CreateAsync(doctor);
            await _repo.SaveChangesAsync();

            return ServiceResponse<int>.Success(doctor.Id);
        }

        public async Task<ServiceResponse<bool>> DeleteDoctorAsync(int id)
        {
            var doctor = await _repo.GetByIdAsync(id);
            if(doctor == null)
            {
                return ServiceResponse<bool>.Fail("Doctor Not Found");
            }

            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();

            return ServiceResponse<bool>.Success(true, "Doctor Deleted Successfully");
        }

        public async Task<ServiceResponse<List<GetDoctorDto>>> GetAllDoctorsAsync()
        {
            var doctors = await _repo.GetAllAsync();
            if (doctors == null || !doctors.Any())
            {
                return ServiceResponse<List<GetDoctorDto>>.Fail("No doctors yet");
            }

            var doctorsDto = doctors.Select(x => new GetDoctorDto
            {
                Id = x.Id,
                Name = x.Name,
                Major = x.Major,
                Salary = x.Salary
            }).ToList();

            return ServiceResponse<List<GetDoctorDto>>.Success(doctorsDto, "Doctors returnd successfully");
        }

        public async Task<ServiceResponse<GetDoctorDto>> GetDoctorByIdAsync(int id)
        {
            var doctor = await _repo.GetByIdAsync(id);

            if(doctor == null)
            {
                return ServiceResponse<GetDoctorDto>.Fail("Doctor not found");
            }

            var doctorDto = new GetDoctorDto
            {
                Id = id,
                Name = doctor.Name,
                Major = doctor.Major,
                Salary = doctor.Salary
            };

            return ServiceResponse<GetDoctorDto>.Success(doctorDto, "Doctor Returned Successfully!");
        }

        public async Task<ServiceResponse<bool>> UpdateDoctorAsync(UpdateDoctorDto doctorDto, int id)
        {
            var doctor = await _repo.GetByIdAsync(id);

            if(doctor == null)
            {
                return ServiceResponse<bool>.Fail("Doctor not found");
            }

            doctor.Name = doctorDto.Name;
            doctor.Salary = doctorDto.Salary;
            doctor.Major = doctorDto.Major;

            await _repo.UpdateAsync(doctor);
            await _repo.SaveChangesAsync();

            return ServiceResponse<bool>.Success(true, "Doctor Updated Successfully");
        }
    }
}
