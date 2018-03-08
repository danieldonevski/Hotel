using System;
using Hotel.DAL.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Hotel.DAL.Repositories.Contracts
{
    public class RoomRepository : IRoomRepository
    {
        #region Fields

        private readonly HotelContext _db;

        #endregion

        #region Constructors

        public RoomRepository()
        {
            _db = new HotelContext();
        }

        public RoomRepository(HotelContext db)
        {
            _db = db;
        }

        #endregion

        #region Methods

        public async Task<Room> GetByRoomIdAsync(Guid id)
        {
            return await _db.Rooms.Where(r => r.RoomId == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _db.Rooms.ToListAsync();
        }

        public async Task CreateRoomAsync(Room room)
        {
            _db.Rooms.Add(room);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(Room room)
        {
            _db.Rooms.Remove(room);

            await _db.SaveChangesAsync();
        }

        public async Task EditRoomAsync(Room room)
        {
            _db.Entry(room).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }

        #endregion
    }
}

