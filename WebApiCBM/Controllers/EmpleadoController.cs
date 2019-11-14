using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiCBM.Models;

namespace WebApiCBM.Controllers
{
    public class EmpleadoController : ApiController
    {
        private CBMEntities db = new CBMEntities();

        // GET: api/Empleado
        public IQueryable<T_Empleados> GetT_Empleados()
        {
            return db.T_Empleados;
        }

        // GET: api/Empleado/5
        [ResponseType(typeof(T_Empleados))]
        public IHttpActionResult GetT_Empleados(int id)
        {
            T_Empleados t_Empleados = db.T_Empleados.Find(id);
            if (t_Empleados == null)
            {
                return NotFound();
            }

            return Ok(t_Empleados);
        }

        // PUT: api/Empleado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutT_Empleados(int id, T_Empleados t_Empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_Empleados.Id_empleado)
            {
                return BadRequest();
            }

            db.Entry(t_Empleados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_EmpleadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleado
        [ResponseType(typeof(T_Empleados))]
        public IHttpActionResult PostT_Empleados(T_Empleados t_Empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_Empleados.Add(t_Empleados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_Empleados.Id_empleado }, t_Empleados);
        }

        // DELETE: api/Empleado/5
        [ResponseType(typeof(T_Empleados))]
        public IHttpActionResult DeleteT_Empleados(int id)
        {
            T_Empleados t_Empleados = db.T_Empleados.Find(id);
            if (t_Empleados == null)
            {
                return NotFound();
            }

            db.T_Empleados.Remove(t_Empleados);
            db.SaveChanges();

            return Ok(t_Empleados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_EmpleadosExists(int id)
        {
            return db.T_Empleados.Count(e => e.Id_empleado == id) > 0;
        }
    }
}