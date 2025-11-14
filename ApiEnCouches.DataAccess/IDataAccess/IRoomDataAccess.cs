using ApiEnCouches.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEnCouches.DataAccess.IDataAccess
{
    public interface IRoomDataAccess
    {
        Task<Room> GetById(int id);
        Task<List<Room>> GetAll();
        Task<Room?> UpdateRoom(int id, Room room);
    }
}
