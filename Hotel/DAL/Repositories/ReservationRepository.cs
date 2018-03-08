using System;
using Hotel.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Contracts
{
    public class ReservationRepository : IReservationRepository
    {
        #region Fields

        private readonly HotelContext _db;

        #endregion

        #region Constructors

        public ReservationRepository()
        {
            _db = new HotelContext();
        }

        public ReservationRepository(HotelContext db)
        {
            _db = db;
        }

        #endregion

        #region Methods

        public async Task<Reservation> GetByReservationIdAsync(Guid id)
        {
            return await _db.Reservations.Where(r => r.ReservationId == id && !r.DeletedDate.HasValue).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _db.Reservations.Where(r => !r.DeletedDate.HasValue).ToListAsync();
        }
        public async Task CreateReservationAsync(Reservation reservation)
        {
            _db.Reservations.Add(reservation);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            reservation.DeletedDate = DateTime.UtcNow;

            _db.Entry(reservation).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }

        public async Task EditReservationAsync(Reservation reservation)
        {
            _db.Entry(reservation).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }

        #endregion
    }
}
