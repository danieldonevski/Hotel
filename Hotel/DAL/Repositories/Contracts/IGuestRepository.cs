using System;
using Hotel.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Contracts
{
    public interface IGuestRepository
    {
        Task<Guest> GetByGuestIdAsync(Guid guestId);

        Task<IEnumerable<Guest>> GetAllAsync();

        Task CreateGuestAsync(Guest guest);

        Task DeleteGuestAsync(Guest guest);

        Task EditGuestAsync(Guest guest);
    }
}
