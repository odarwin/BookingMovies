﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingMovie.Dominio.Entidades
{
    public partial class BaseEntity
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
