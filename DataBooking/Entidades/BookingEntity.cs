using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingMovie.Dominio.Entidades
{
    public partial class BookingEntity
    {
        public DateTime Date { get; set; }
        public int? CustomerId { get; set; }
        public int Id { get; set; }
        public int SeatId { get; set; }
        public int BillboardId { get; set; }

        public virtual BillboardEntity Billboard { get; set; }
        public virtual CustomerEntity Customer { get; set; }
        public virtual SeatEntity Seat { get; set; }
    }
}
