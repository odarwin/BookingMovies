using BookingMovie.Dominio.Entidades;
using BookingMovies.Aplicacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingMovieWebApp2.Controllers
{
    public class BillboardController : ControllerBase
    {
        private static IBillboardService I_BillboardEntity;

        // GET: BillboardController
        public ActionResult Index()
        {
            return RedirectToAction("GetBillboards");
        }

        // GET: BillboardController/Details/5
        public async Task<IEnumerable<BillboardEntity>> GetBillboards()
        {
            var billboards = await I_BillboardEntity.GetAllAsync();
            return billboards;
        }

        // GET: BillboardController/Details/5
        public BillboardEntity Details(int id)
        {
            var cartelera = I_BillboardEntity.Details(id);
            return cartelera;
        }

        // POST: BillboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BillboardEntity entidad)
        {
            try
            {
                var r= await I_BillboardEntity.Create(entidad);
                return Ok();
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // POST: BillboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BillboardEntity entidad)
        {
            try
            {
                var r = await I_BillboardEntity.Edit(entidad);
                return Ok();
            }
            catch
            {
                return StatusCode(404);
            }
        }


        // POST: BillboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var r = await I_BillboardEntity.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(404);
            }
        }
    }
}
