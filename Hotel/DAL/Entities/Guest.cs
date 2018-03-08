using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.DAL.Entities
{
    public class Guest
    {
        public Guid GuestId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IDNumber { get; set; }

        public int? Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}