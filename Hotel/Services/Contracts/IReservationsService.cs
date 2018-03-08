using Hotel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public interface IReservationsService
    {
        Task<IEnumerable<Reservation>> GetAllAsync();

        Task<Reservation> GetByReservationIdAsync(Guid reservationId);

        Task CreateReservationAsync(Reservation reservation);

        Task DeleteReservationAsync(Reservation reservation);

        Task EditReservationAsync(Reservation reservation);
    }
}


