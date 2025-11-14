namespace ApiEnCouches.Controllers.User
{
    using ApiEnCouches.Service.DataTransferObject;
    using ApiEnCouches.Service.IService;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;

        public RoomController (IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GetRoomDto> roomDtos = await roomService.GetAll();
            if(roomDtos == null || roomDtos.Count == 0)
            {
                return NotFound();
            }
            return Ok(roomDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetRoomDto roomDto = await roomService.GetById(id);
            if (roomDto == null)
            {
                return NotFound();
            }
            return Ok(roomDto);
        }

        // Update une room
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] GetRoomDto roomDto)
        {
            GetRoomDto? updatedRoom = await roomService.UpdateRoom(id, roomDto);
            if (updatedRoom == null)
            {
                return NotFound();
            }
            return Ok(updatedRoom);
        }
    }
}