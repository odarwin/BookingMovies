using BookingMovie.Dominio.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingMovies.Aplicacion
{
    public interface IBillboardService
    {
        Task<IEnumerable<BillboardEntity>> GetAllAsync();
        BillboardEntity Details(int id);
        Task<IdentityResult> Create(BillboardEntity entidad);
        Task<IdentityResult> Edit(BillboardEntity entidad);
        Task<IdentityResult> Delete(int id);
    }
}
