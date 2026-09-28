using Hospital.BL.Services.Interfaces;
using Hospital.BL.DTOs.Patient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }

        // Get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            if (!patients.IsSuccess) return NotFound(patients);
            return Ok(patients);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (!patient.IsSuccess) return NotFound(patient);
            return Ok(patient);
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientDto patientDto)
        {
            var patient = await _patientService.CreatePatientAsync(patientDto);
            if (!patient.IsSuccess) return BadRequest(patient);
            return Ok(patient);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePatientDto patientDto)
        {
            var patient = await _patientService.UpdatePatientAsync(patientDto, id);
            if (!patient.IsSuccess) return NotFound(patient);
            return Ok(patient);
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _patientService.DeletePatientAsync(id);
            if (!patient.IsSuccess) return NotFound(patient);
            return Ok(patient);
        }

    }
}
