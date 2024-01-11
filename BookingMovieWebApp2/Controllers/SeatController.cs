using BookingMovie.Dominio.Entidades;
using BookingMovies.Aplicacion;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingMovieWebApp2.Controllers
{
    public class SeatController : ControllerBase
    {
        private static IButacaService I_SeatEntity;
        //a. Implementar controlador para administrar butaca 
        public SeatController()
        {
            
        }

        public SeatEntity Details(int id)
        {
            var butaca = I_SeatEntity.Details(id);
            return butaca;
        }
        public IActionResult Index()
        {

            return RedirectToAction("GetButacas");
        }

        public async Task<IEnumerable<SeatEntity>> GetButacas()
        {
            var butacas=await I_SeatEntity.GetAllAsync();
            return butacas;
        }

        [HttpPost]
        public async Task<ActionResult> Create(SeatEntity entidad)
        {
            IdentityResult resultado = await I_SeatEntity.Create(entidad);
            if (resultado.Succeeded)
            {
                return Ok();
            }
            return StatusCode(404);
            
        }
        [HttpPost]
        public async Task<ActionResult> Edit(SeatEntity entidad)
        {
            var resultado = await I_SeatEntity.Edit(entidad);
            if (resultado.Succeeded)
            {
                return Ok();
            }
            return StatusCode(404);

        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await I_SeatEntity.Delete(id);
            if (resultado.Succeeded)
            {
                return Ok();
            }
            return StatusCode(404);

        }
    }
}
