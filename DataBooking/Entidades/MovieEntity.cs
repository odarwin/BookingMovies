using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingMovie.Dominio.Entidades
{
    public partial class MovieEntity
    {
        public MovieEntity()
        {
            BillboardEntity = new HashSet<BillboardEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int AllowedAge { get; set; }
        public int LengthMinutes { get; set; }

        public virtual ICollection<BillboardEntity> BillboardEntity { get; set; }
    }
}
