using System;
using Hotel.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Contracts
{
    public interface IRoomRepository
    {
        Task<Room> GetByRoomIdAsync(Guid roomId);

        Task<IEnumerable<Room>> GetAllAsync();

        Task CreateRoomAsync(Room room);

        Task DeleteRoomAsync(Room room);

        Task EditRoomAsync(Room room);
    }
}

