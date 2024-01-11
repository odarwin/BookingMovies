using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBooking.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ServiciesBooking.Repositorios
{

    public class BookingMoviesServices
    {
        private readonly BookingMoviesDBContext _context;

        public BookingMoviesServices()
        {
            this._context = new BookingMoviesDBContext();
        }
    }
}
