using ApiEnCouches.DataAccess.Entity;
using ApiEnCouches.DataAccess.IDataAccess;
using ApiEnCouches.Service.DataTransferObject;
using ApiEnCouches.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEnCouches.Service.Service
{
    public class SlotService : ISlotService
    {
        private readonly ISlotDataAccess slotDataAccess;

        public SlotService(ISlotDataAccess slotDataAccess)
        {
            this.slotDataAccess = slotDataAccess;
        }

        public async Task<GetTimeslotDto> GetById(int id)
        {
            TimeSlot slot = await slotDataAccess.GetById(id);
            if(slot == null)
            {
                return null;
            }

            return new GetTimeslotDto
            {
                Id = slot.Id,
                StartTime = slot.StartTime,
                EndTime = slot.EndTime,
                UserId = slot.UserId
            };
        }

        public async Task<List<GetTimeslotDto>> GetAll()
        {
            List<TimeSlot?> slot = await slotDataAccess.GetAll();
            if (slot == null)
            {
                return null;
            }
            return slot.Select(x => new GetTimeslotDto
            {
                Id = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                UserId = x.UserId
            }).ToList();
        }

        public async Task<GetTimeslotDto?> UpdateSlot(int id, GetTimeslotDto slotDto)
        {
            var slot = new TimeSlot
            {
                StartTime = slotDto.StartTime,
                EndTime = slotDto.EndTime,
                UserId = slotDto.UserId
            };
            TimeSlot? updatedSlot = await slotDataAccess.UpdateSlot(id, slot);
            if (updatedSlot == null)
            {
                return null;
            }
            return new GetTimeslotDto
            {
                Id = updatedSlot.Id,
                StartTime = updatedSlot.StartTime,
                EndTime = updatedSlot.EndTime,
                UserId = updatedSlot.UserId
            };
        }
    }
}
