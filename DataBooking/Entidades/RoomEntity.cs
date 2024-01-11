using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingMovie.Dominio.Entidades
{
    public partial class RoomEntity
    {
        public RoomEntity()
        {
            BillboardEntity = new HashSet<BillboardEntity>();
            SeatEntity = new HashSet<SeatEntity>();
        }

        public string Name { get; set; }
        public int Number { get; set; }
        public int Id { get; set; }

        public virtual ICollection<BillboardEntity> BillboardEntity { get; set; }
        public virtual ICollection<SeatEntity> SeatEntity { get; set; }
    }
}
