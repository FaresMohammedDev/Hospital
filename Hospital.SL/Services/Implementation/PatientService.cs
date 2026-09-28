using Hospital.BL.Common;
using Hospital.BL.DTOs.Patient;
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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _repo;
        public PatientService(IPatientRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public async Task<ServiceResponse<int>> CreatePatientAsync(CreatePatientDto patientDto)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                Illness = patientDto.Illness,
                Birthday = patientDto.Birthday
            };

            await _repo.CreateAsync(patient);
            await _repo.SaveChangesAsync();
            return ServiceResponse<int>.Success(patient.Id, "Patient Created successfully");
        }

        public async Task<ServiceResponse<bool>> DeletePatientAsync(int id)
        {
            var patient = await _repo.GetByIdAsync(id);

            if(patient == null)
            {
                return ServiceResponse<bool>.Fail("Patient Not Found");
            }

            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();

            return ServiceResponse<bool>.Success(true, "Patient deleted successfylly");
        }

        public async Task<ServiceResponse<List<GetPatientDto>>> GetAllPatientsAsync()
        {
            var patients = await _repo.GetAllAsync();
            if (patients == null || !patients.Any())
            {
                return ServiceResponse<List<GetPatientDto>>.Fail("Patients not found");
            }

            var patientsDto = patients.Select(x => new GetPatientDto
            {
                Id = x.Id,
                Name = x.Name,
                Illness = x.Illness,
                Birthday = x.Birthday
            }).ToList();

            return ServiceResponse<List<GetPatientDto>>.Success(patientsDto);
        }

        public async Task<ServiceResponse<GetPatientDto>> GetPatientByIdAsync(int id)
        {
            var patient = await _repo.GetByIdAsync(id);
            if (patient == null)
            {
                return ServiceResponse<GetPatientDto>.Fail("Patient not found");
            }

            var patientDto = new GetPatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Illness = patient.Illness,
                Birthday = patient.Birthday
            };

            return ServiceResponse<GetPatientDto>.Success(patientDto, "Returned Patient Successfully");
        }

        public async Task<ServiceResponse<bool>> UpdatePatientAsync(UpdatePatientDto patientDto, int id)
        {
            var patient = await _repo.GetByIdAsync(id);
            if (patient == null)
            {
                return ServiceResponse<bool>.Fail("Patient not found");
            }

            patient.Name = patientDto.Name;
            patient.Illness = patientDto.Illness;
            patient.Birthday = patientDto.Birthday;

            await _repo.UpdateAsync(patient);
            await _repo.SaveChangesAsync();

            return ServiceResponse<bool>.Success(true, "Patient updated successfully");
        }
    }
}
