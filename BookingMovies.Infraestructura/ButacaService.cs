using BookingMovies.Aplicacion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BookingMovie.Dominio.Entidades;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookingMovies.Infraestructura
{
    public class ButacaService : IButacaService
    {
        private readonly BookingMoviesDBContext _context;
        public ButacaService()
        {
            this._context = new BookingMoviesDBContext();
        }
        //a.Implementar el método con transaccionalidad para inhabilitar la butaca y cancelar la reserva.

        public bool InhabilitarButacaReserva(int idreserva, int idbutaca)
        {
            try
            {
                var reserva = this._context.BookingEntity.Find(idreserva);
                var butaca = this._context.SeatEntity.Find(idbutaca);
                butaca.RoomId = 0;
                butaca.Room = null;
                if(reserva == null || butaca==null) {
                    Console.WriteLine("No se encontro la reserva o la butaca");
                    return false;
                }
                _context.Entry(reserva).State = EntityState.Deleted;
                _context.Entry(butaca).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
                return false;
            }
            
        }

        //b. Implementar el método con transaccionalidad para cancelar la cartelera y cancelar todas las reservas de la sala,
        //adicional se debe habilitar las butacas e imprimir por consola la lista de clientes que fueron afectados.
        public bool CancelarCartelera(int idcartelera)
        {
            var cartelera = this._context.BillboardEntity.Find(idcartelera);
            if (cartelera == null)
            {
                return false;
            }
            int id_sala = (int)cartelera.RoomId;
            var reservas = (
                from _cartelera in _context.BillboardEntity
                join sala in _context.RoomEntity
                on _cartelera.RoomId equals sala.Id
                join _reserva in _context.BookingEntity
                on _cartelera.Id equals _reserva.BillboardId 
                where _cartelera.Id == idcartelera && sala.Id==id_sala
                select _reserva
                );
            foreach (var elem in reservas)
            {
                elem.BillboardId = 0;
                elem.Billboard = null;
                _context.Entry(elem).State = EntityState.Modified;
                MostrarClientes(elem.CustomerId);
            }
            //habiliatar butacas
            HabilitarButacas(id_sala);
            _context.Entry(cartelera).State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }

        private void MostrarClientes(int? idCliente)
        {
            try
            {
                var cliente = _context.CustomerEntity.Find(idCliente);
                Console.WriteLine("Cliente: " + cliente.Name + " " + cliente.Lastname);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
            }

        }

        private void HabilitarButacas(int id_sala)
        {
            try
            {
               var butacas = (
               from butaca in _context.SeatEntity
               where butaca.RoomId == id_sala
               select butaca
               );
                foreach (var elem in butacas)
                {
                    elem.RoomId = 0;
                    elem.Room = null;
                    _context.Entry(elem).State = EntityState.Modified;
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine("error: " + ex.Message);
            }

        }
        //c.Si se trata de cancelar una cartelera cuando la función sea menor a la fecha actual
        //se debe lanzar una excepción personalizada con el mensaje: 'No se puede cancelar funciones de
        //la cartelera con fecha anterior a la actual'.
        public void CancelarCarteleraFuncion(int id_cartelera)
        {
            try
            {
                var cartelera = _context.BillboardEntity.Find(id_cartelera);
                if (cartelera == null)
                {
                    Console.WriteLine("Sin cartelera");
                }

                DateTime fecha1 = cartelera.Date;
                DateTime fecha2 = DateTime.Now;
                int fechaResultado = DateTime.Compare(fecha1, fecha2);
                if (fechaResultado < 0)
                {
                    Console.WriteLine("No se puede cancelar funciones de la cartelera con fecha anterior a la actual");
                }
                else
                {
                    _context.Entry(cartelera).State = EntityState.Deleted;
                    _context.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("error: " + ex.Message);
            }
        }

        public async Task<IEnumerable<SeatEntity>> GetAllAsync()
        {
            return await _context.SeatEntity.OrderBy(s=>s.Id).ToListAsync();
        }

        public async Task<IdentityResult> Create(SeatEntity entidad)
        {
            try
            {
                await _context.SeatEntity.AddAsync(entidad);
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError { Code="402",Description="Fallo al crear: "+ex.Message });
            }
        }

        public async Task<IdentityResult> Edit(SeatEntity entidad)
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

        public async Task<IdentityResult> Delete(int id)
        {
            try
            {
                var butaca = _context.SeatEntity.Find(id);
                _context.Entry(butaca).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError { Code = "402", Description = "Fallo al eliminar: " + ex.Message });
            }
        }

        public SeatEntity Details(int id)
        {
            var r = _context.SeatEntity.Find(id);
            return r;
        }

    }
}
