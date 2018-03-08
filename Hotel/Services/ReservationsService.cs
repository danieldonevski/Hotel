using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Hotel.DAL;
using Hotel.DAL.Entities;
using Hotel.DAL.Repositories.Contracts;

namespace Hotel.Services
{
    public class ReservationsService : IReservationsService
    {
        #region Fields

        private readonly IReservationRepository _reservationRepository;

        #endregion

        #region Constructors

        public ReservationsService()
        {
            HotelContext _db = new HotelContext();
            _reservationRepository = new ReservationRepository(_db);
        }

        public ReservationsService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetByReservationIdAsync(Guid reservationId)
        {
            return await _reservationRepository.GetByReservationIdAsync(reservationId);
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            reservation.ReservationId = Guid.NewGuid();

            await _reservationRepository.CreateReservationAsync(reservation);
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            await _reservationRepository.DeleteReservationAsync(reservation);
        }

        public async Task EditReservationAsync(Reservation reservation)
        {
            await _reservationRepository.EditReservationAsync(reservation);
        }

        #endregion
    }
}