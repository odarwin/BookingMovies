using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingMovie.Dominio.Entidades
{
    public partial class SeatEntity
    {
        public SeatEntity()
        {
            BookingEntity = new HashSet<BookingEntity>();
        }

        public int Number { get; set; }
        public int RowNumber { get; set; }
        public int RoomId { get; set; }
        public int Id { get; set; }

        public virtual RoomEntity Room { get; set; }
        public virtual ICollection<BookingEntity> BookingEntity { get; set; }
    }
}
