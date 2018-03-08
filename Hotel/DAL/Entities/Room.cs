using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.DAL.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }

        public int RoomNumber { get; set; }

        public int NumberOfBeds { get; set; }

        public bool SmokingAllowed { get; set; }

        public decimal PricePerNight { get; set; }

        public int RoomType { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}