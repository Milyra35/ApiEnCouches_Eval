using ApiEnCouches.Service.DataTransferObject;
using ApiEnCouches.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace ApiEnCouches.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class SlotController : Controller
    {
        private readonly ISlotService slotService;

        public SlotController(ISlotService slotService)
        {
            this.slotService = slotService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GetTimeslotDto> slotDtos = await slotService.GetAll();
            if(slotDtos == null || slotDtos.Count == 0)
            {
                return NotFound();
            }

            return Ok(slotDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetTimeslotDto slotDto = await slotService.GetById(id);
            if(slotDto == null)
            {
                return NotFound();
            }
            return Ok(slotDto);
        }
    }
}
