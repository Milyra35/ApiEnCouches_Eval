using ApiEnCouches.Service.DataTransferObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEnCouches.Service.IService
{
    public interface ISlotService
    {
        Task<GetTimeslotDto> GetById(int id);
        Task<List<GetTimeslotDto>> GetAll();
        Task<GetTimeslotDto?> UpdateSlot(int id, GetTimeslotDto slotDto);
    }
}