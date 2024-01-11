using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingMovie.Dominio.Entidades
{
    public partial class CustomerEntity
    {
        public CustomerEntity()
        {
            BookingEntity = new HashSet<BookingEntity>();
        }

        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BookingEntity> BookingEntity { get; set; }
    }
}
