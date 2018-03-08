using System;
using Hotel.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace Hotel.DAL.Repositories.Contracts
{
    public class GuestRepository : IGuestRepository
    {
        #region Fields

        private readonly HotelContext _db;

        #endregion

        #region Constructors

        public GuestRepository()
        {
            _db = new HotelContext();
        }

        public GuestRepository(HotelContext db)
        {
            _db = db;
        }

        #endregion

        #region Methods

        public async Task<Guest> GetByGuestIdAsync(Guid guestId)
        {
            return await _db.Guests.Where(r => r.GuestId == guestId).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Guest>> GetAllAsync()
        {
            return await _db.Guests.ToListAsync();
        }

        public async Task CreateGuestAsync(Guest guest)
        {
            _db.Guests.Add(guest);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteGuestAsync(Guest guest)
        {
            _db.Guests.Remove(guest);

            await _db.SaveChangesAsync();
        }

        public async Task EditGuestAsync(Guest guest)
        {
            _db.Entry(guest).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }

        #endregion
    }
}
