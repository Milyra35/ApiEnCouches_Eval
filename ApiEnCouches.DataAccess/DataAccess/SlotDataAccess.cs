using ApiEnCouches.DataAccess.Entity;
using ApiEnCouches.DataAccess.IDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEnCouches.DataAccess.DataAccess
{
    public class SlotDataAccess : ISlotDataAccess
    {
        private readonly AppDbContext context;

        public SlotDataAccess(AppDbContext context)
        {
            this.context = context;
        }

        //public async Task<bool> IsSlotAvailable(int roomId, DateTime startTime, DateTime endTime)
        //{
        //    var overlappingSlots = await this.context.Slots
        //        .Where(s => s.RoomId == roomId &&
        //                    s.StartTime < endTime &&
        //                    s.EndTime > startTime)
        //        .ToListAsync();
        //    return !overlappingSlots.Any();
        //}

        public async Task<List<TimeSlot>> GetAll()
        {
            return await this.context.TimeSlots.ToListAsync();
        }

        public async Task<TimeSlot?> GetById(int id)
        {
            return await this.context.TimeSlots.FindAsync(id);
        }

        public async Task<TimeSlot?> UpdateSlot(int id, TimeSlot slot)
        {
            var existingSlot = await this.context.TimeSlots.FindAsync(id);
            if (existingSlot == null)
            {
                return null;
            }
            existingSlot.StartTime = slot.StartTime;
            existingSlot.EndTime = slot.EndTime;
            existingSlot.UserId = slot.UserId;
            await this.context.SaveChangesAsync();
            return existingSlot;
        }
    }
}
