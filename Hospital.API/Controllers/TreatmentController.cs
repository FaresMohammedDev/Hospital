using Hospital.BL.Services.Interfaces;
using Hospital.BL.DTOs.Treatment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;
        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService ?? throw new ArgumentNullException(nameof(treatmentService));
        }

        // Get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var treatment = await _treatmentService.GetAllTreatmentsAsync();
            if (!treatment.IsSuccess) return NotFound(treatment);
            return Ok(treatment);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var treatment = await _treatmentService.GetTreatmentByIdAsync(id);
            if (!treatment.IsSuccess) return NotFound(treatment);
            return Ok(treatment);
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTreatmentDto treatmentDto)
        {
            var treatment = await _treatmentService.CreateTreatmentAsync(treatmentDto);
            if (!treatment.IsSuccess) return BadRequest(treatment);
            return Ok(treatment);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTreatmentDto treatmentDto)
        {
            var treatment = await _treatmentService.UpdateTreatmentAsync(treatmentDto, id);
            if (!treatment.IsSuccess) return NotFound(treatment);
            return Ok(treatment);
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var treatment = await _treatmentService.DeleteTreatmentAsync(id);
            if (!treatment.IsSuccess) return NotFound(treatment);
            return Ok(treatment);
        }
    }
}
