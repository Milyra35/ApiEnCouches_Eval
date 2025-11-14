using ApiEnCouches.DataAccess.Entity;

namespace ApiEnCouches.DataAccess.IDataAccess
{
    public interface ISlotDataAccess
    {
        Task<TimeSlot?> GetById(int id);
        Task<List<TimeSlot>> GetAll();
        Task<TimeSlot?> UpdateSlot(int id, TimeSlot slot);
    }
}