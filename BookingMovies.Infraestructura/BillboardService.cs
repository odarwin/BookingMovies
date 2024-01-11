using BookingMovie.Dominio.Entidades;
using BookingMovies.Aplicacion;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMovies.Infraestructura
{
    public class BillboardService: IBillboardService
    {
        private readonly BookingMoviesDBContext _context;

        public BillboardService()
        {
            this._context = new BookingMoviesDBContext();
        }

        public async Task<IdentityResult> Create(BillboardEntity entidad)
        {
            try
            {
                await _context.BillboardEntity.AddAsync(entidad);
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError { Code = "402", Description = "Fallo al crear: " + ex.Message });
            }
        }

        public async Task<IdentityResult> Delete(int id)
        {
            try
            {
                var butaca = _context.BillboardEntity.Find(id);
                _context.Entry(butaca).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError { Code = "402", Description = "Fallo al eliminar: " + ex.Message });
            }
        }

        public BillboardEntity Details(int id)
        {
            var r = _context.BillboardEntity.Find(id);
            return r;
        }

        public async Task<IdentityResult> Edit(BillboardEntity entidad)
        {
            try
            {
                _context.Entry(entidad).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError { Code = "402", Description = "Fallo al editar: " + ex.Message });
            }
        }

        public async Task<IEnumerable<BillboardEntity>> GetAllAsync()
        {
            return await _context.BillboardEntity.OrderBy(s=>s.Id).ToListAsync();
        }

      
    }
}
