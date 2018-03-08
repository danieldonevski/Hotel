using System;
using Hotel.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Contracts
{
    public interface IReservationRepository
    {
        Task<Reservation> GetByReservationIdAsync(Guid id);

        Task<IEnumerable<Reservation>> GetAllAsync();

        Task CreateReservationAsync(Reservation reservation);

        Task DeleteReservationAsync(Reservation reservation);

        Task EditReservationAsync(Reservation reservation);
    }
}
