using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingMovie.Dominio.Entidades
{
    public partial class BillboardEntity
    {
        public BillboardEntity()
        {
            BookingEntity = new HashSet<BookingEntity>();
        }

        public DateTime Date { get; set; }
        public byte[] StartTime { get; set; }
        public string EndTime { get; set; }
        public int? MovieId { get; set; }
        public int? RoomId { get; set; }
        public int Id { get; set; }

        public virtual MovieEntity Movie { get; set; }
        public virtual RoomEntity Room { get; set; }
        public virtual ICollection<BookingEntity> BookingEntity { get; set; }
    }
}
