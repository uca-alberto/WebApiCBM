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
    public class ClienteController : ApiController
    {
        private CBMEntities db = new CBMEntities();

        // GET: api/Cliente
        public IQueryable<T_Clientes> GetT_Clientes()
        {
            return db.T_Clientes;
        }

        // GET: api/Cliente/5
        [ResponseType(typeof(T_Clientes))]
        public IHttpActionResult GetT_Clientes(int id)
        {
            T_Clientes t_Clientes = db.T_Clientes.Find(id);
            if (t_Clientes == null)
            {
                return NotFound();
            }

            return Ok(t_Clientes);
        }

        // PUT: api/Cliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutT_Clientes(int id, T_Clientes t_Clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_Clientes.Id_cliente)
            {
                return BadRequest();
            }

            db.Entry(t_Clientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_ClientesExists(id))
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

        // POST: api/Cliente
        [ResponseType(typeof(T_Clientes))]
        public IHttpActionResult PostT_Clientes(T_Clientes t_Clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_Clientes.Add(t_Clientes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_Clientes.Id_cliente }, t_Clientes);
        }

        // DELETE: api/Cliente/5
        [ResponseType(typeof(T_Clientes))]
        public IHttpActionResult DeleteT_Clientes(int id)
        {
            T_Clientes t_Clientes = db.T_Clientes.Find(id);
            if (t_Clientes == null)
            {
                return NotFound();
            }

            db.T_Clientes.Remove(t_Clientes);
            db.SaveChanges();

            return Ok(t_Clientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_ClientesExists(int id)
        {
            return db.T_Clientes.Count(e => e.Id_cliente == id) > 0;
        }
    }
}