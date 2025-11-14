using ApiEnCouches.Service.DataTransferObject;

namespace ApiEnCouches.Service.IService
{
    public interface IRoomService
    {
        Task<GetRoomDto> GetById(int id);
        Task<List<GetRoomDto>> GetAll();
        Task<GetRoomDto?> UpdateRoom(int id, GetRoomDto roomDto);
    }
}