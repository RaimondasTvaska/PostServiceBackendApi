using Microsoft.AspNetCore.Mvc;
using PostServiceBackendApi.Entities;
using PostServiceBackendApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServiceBackendApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _parcelService;

        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Parcel>>> GetAll()
        {
            return Ok(await _parcelService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Parcel>>> GetById(int id)
        {
            var parcel = await _parcelService.GetByIdAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }
            return Ok(parcel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Parcel parcel)
        {
            return Ok(await _parcelService.AddAsync(parcel));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateParcel(Parcel parcel)
        {
            await _parcelService.UpdateParcelAsync(parcel);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _parcelService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("FilterByPost/{postId}")]
        public async Task<IActionResult> GetBettersByHorseIdAsync(int postId)
        {
            return Ok(await _parcelService.GetParcelsByPostIdAsync(postId));
        }
    }
}
