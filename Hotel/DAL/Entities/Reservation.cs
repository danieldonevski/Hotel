using System;
using System.Collections.Generic;

namespace Hotel.DAL.Entities
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }

        public string MainGuestName { get; set; }

        public decimal TotalAmount { get; set; }

        public bool Confirmed { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

    }
}