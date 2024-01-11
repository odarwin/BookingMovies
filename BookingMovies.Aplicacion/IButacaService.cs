using BookingMovie.Dominio.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingMovies.Aplicacion
{
    public interface IButacaService
    {
        Task<IEnumerable<SeatEntity>> GetAllAsync();
        Task<IdentityResult> Create(SeatEntity entidad);
        Task<IdentityResult> Edit(SeatEntity entidad);
        Task<IdentityResult> Delete(int id);
        SeatEntity Details(int id);
    }
}
