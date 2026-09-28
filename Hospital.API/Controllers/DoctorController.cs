using Hospital.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Hospital.BL.DTOs.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }

        // Get All Doctors
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            if (!doctors.IsSuccess) return NotFound(doctors);
            return Ok(doctors);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (!doctor.IsSuccess) return NotFound(doctor);
            return Ok(doctor);
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoctorDto doctorDto)
        {
            var doctor = await _doctorService.CreateDoctorAsync(doctorDto);
            if (!doctor.IsSuccess) return BadRequest(doctor);
            return Ok(doctor);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateDoctorDto doctorDto, int id)
        { 
            var doctor = await _doctorService.UpdateDoctorAsync(doctorDto, id);
            if (!doctor.IsSuccess) return NotFound(doctor);
            return Ok(doctor);
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.DeleteDoctorAsync(id);
            if (!doctor.IsSuccess) return NotFound(doctor);
            return Ok(doctor);
        }

    }
}
