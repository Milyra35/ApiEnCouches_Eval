using ApiEnCouches.DataAccess.Entity;
using ApiEnCouches.DataAccess.IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace ApiEnCouches.DataAccess.DataAccess
{
    public class RoomDataAccess : IRoomDataAccess
    {
        private readonly AppDbContext context;

        public RoomDataAccess(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Room> GetById(int id)
        {
            return await this.context.Rooms.FindAsync(id);
        }

        public async Task<List<Room>> GetAll()
        {
            return await this.context.Rooms.ToListAsync();
        }

        public async Task<Room?> UpdateRoom(int id, Room room)
        {
            Room? existingRoom = await this.context.Rooms.FindAsync(id);
            if (existingRoom == null)
            {
                return null;
            }
            existingRoom.Name = room.Name;
            existingRoom.Capacity = room.Capacity;
            existingRoom.Timeslots = room.Timeslots;

            await this.context.SaveChangesAsync();
            return existingRoom;
        }
    }
}