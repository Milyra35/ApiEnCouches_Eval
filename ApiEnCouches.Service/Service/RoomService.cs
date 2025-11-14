namespace ApiEnCouches.Service.Service
{
    using ApiEnCouches.DataAccess.Entity;
    using ApiEnCouches.DataAccess.IDataAccess;
    using ApiEnCouches.Service.DataTransferObject;
    using ApiEnCouches.Service.IService;
    using System.Threading.Tasks;

    public class RoomService : IRoomService
    {
        private readonly IRoomDataAccess roomDataAccess;

        public RoomService(IRoomDataAccess roomDataAccess)
        {
            this.roomDataAccess = roomDataAccess;
        }

        public async Task<GetRoomDto> GetById(int id)
        {
            Room room = await roomDataAccess.GetById(id);
            if (room == null)
            {
                return null;
            }

            return new GetRoomDto()
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity,
                Timeslots = room.Timeslots?.Select(x => new GetTimeslotDto
                {
                    Id = x.Id,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    UserId = x.UserId
                }).ToList() ?? new List<GetTimeslotDto>()
            };
        }

        public async Task<List<GetRoomDto>> GetAll()
        {
            List<Room> rooms = await roomDataAccess.GetAll();
            var roomDtos = rooms.Select(room => new GetRoomDto()
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity,
                Timeslots = room.Timeslots?.Select(x => new GetTimeslotDto
                {
                    Id = x.Id,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    UserId = x.UserId
                }).ToList() ?? new List<GetTimeslotDto>()
            }).ToList();
            return roomDtos;
        }

        // Update une room 
        public async Task<GetRoomDto?> UpdateRoom(int id, GetRoomDto roomDto)
        {
            var room = new Room
            {
                Name = roomDto.Name,
                Capacity = roomDto.Capacity,
                Timeslots = roomDto.Timeslots?.Select(x => new TimeSlot
                {
                    Id = x.Id,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    UserId = x.UserId
                }).ToList() ?? new List<TimeSlot>()
            };

            var updatedRoom = await roomDataAccess.UpdateRoom(id, room);

            if (updatedRoom == null)
            {
                return null;
            }

            return new GetRoomDto()
            {
                Id = updatedRoom.Id,
                Name = updatedRoom.Name,
                Capacity = updatedRoom.Capacity,
                Timeslots = updatedRoom.Timeslots?.Select(x => new GetTimeslotDto
                {
                    Id = x.Id,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    UserId = x.UserId
                }).ToList() ?? new List<GetTimeslotDto>()
            };
        }
    }
}