using Hospital.BL.Common;
using Hospital.BL.DTOs.Treatment;
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
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepo _treatmentRepo;
        private readonly IDoctorRepo _doctorRepo;
        private readonly IPatientRepo _patientRepo;
        public TreatmentService(ITreatmentRepo treatmentRepo, IDoctorRepo doctorRepo, IPatientRepo patientRepo)
        {
            _treatmentRepo = treatmentRepo ?? throw new ArgumentNullException(nameof(treatmentRepo));
            _doctorRepo = doctorRepo ?? throw new ArgumentNullException(nameof(doctorRepo));
            _patientRepo = patientRepo ?? throw new ArgumentNullException(nameof(patientRepo));
        }
        public async Task<ServiceResponse<int>> CreateTreatmentAsync(CreateTreatmentDto treatmentDto)
        {
            var doctor = await _doctorRepo.GetByIdAsync(treatmentDto.DoctorId);
            var patient = await _patientRepo.GetByIdAsync(treatmentDto.PatientId);
            if(doctor == null || patient == null)
            {
                return ServiceResponse<int>.Fail("Doctor or Patient not found");
            }

            var treatment = new Treatment
            {
                TreatmentDateTime = treatmentDto.TreatmentDateTime,
                PatientId = treatmentDto.PatientId,
                DoctorId = treatmentDto.DoctorId,
            };

            await _treatmentRepo.CreateAsync(treatment);
            await _treatmentRepo.SaveChangesAsync();

            return ServiceResponse<int>.Success(treatment.Id, "Treatment created successfully");

        }

        public async Task<ServiceResponse<bool>> DeleteTreatmentAsync(int id)
        {
            var treatment = await _treatmentRepo.GetByIdAsync(id);
            if (treatment == null)
            {
                return ServiceResponse<bool>.Fail("Treatment not found");
            }

            await _treatmentRepo.DeleteAsync(id);
            await _treatmentRepo.SaveChangesAsync();

            return ServiceResponse<bool>.Success(true, "Treatment deleted successfully");
        }

        public async Task<ServiceResponse<List<GetTreatmentDto>>> GetAllTreatmentsAsync()
        {
            var treatments = await _treatmentRepo.GetAllTreatmentsWithDetailsAsync();

            if (treatments == null || !treatments.Any())
            {
                return ServiceResponse<List<GetTreatmentDto>>.Fail("Treatments not found");
            }

            var treatmentsDto = treatments.Select(x => new GetTreatmentDto
            {
                TreatmentDateTime = x.TreatmentDateTime,
                DoctorName = x.Doctor!.Name,
                Major = x.Doctor.Major,
                PatientName = x.Patient!.Name,
                Illness = x.Patient.Illness
            }).ToList();

            return ServiceResponse<List<GetTreatmentDto>>.Success(treatmentsDto);
        }

        public async Task<ServiceResponse<GetTreatmentDto>> GetTreatmentByIdAsync(int id)
        {
            var treatment = await _treatmentRepo.GetTreatmentByIdWithDetailsAsync(id);
            if(treatment == null)
            {
                return ServiceResponse<GetTreatmentDto>.Fail("Treatment not found");
            }

            var treatmentDto = new GetTreatmentDto
            {
                TreatmentDateTime = treatment.TreatmentDateTime,
                DoctorName  = treatment.Doctor!.Name,
                Major = treatment.Doctor.Major,
                PatientName = treatment.Patient!.Name,
                Illness = treatment.Patient.Illness
            };

            return ServiceResponse<GetTreatmentDto>.Success(treatmentDto, "Treatment returned successfully");
        }

        public async Task<ServiceResponse<bool>> UpdateTreatmentAsync(UpdateTreatmentDto treatmentDto, int id)
        {
            var treatment = await _treatmentRepo.GetByIdAsync(id);
            if(treatment == null)
            {
                return ServiceResponse<bool>.Fail("Treatment not found");
            }

            treatment.TreatmentDateTime = treatmentDto.TreatmentDateTime;
            treatment.PatientId = treatmentDto.PatientId;
            treatment.DoctorId = treatmentDto.DoctorId;

            await _treatmentRepo.UpdateAsync(treatment);
            await _treatmentRepo.SaveChangesAsync();

            return ServiceResponse<bool>.Success(true, "Treatment Updated succesfully");
        }
    }
}
