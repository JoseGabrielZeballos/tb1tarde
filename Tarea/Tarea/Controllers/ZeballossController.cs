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
using Tarea.Models;

namespace Tarea.Controllers
{
    public class ZeballossController : ApiController
    {
        private DataContex db = new DataContex();

        // GET: api/Zeballoss
        [Authorize]
        public IQueryable<Zeballos> GetZeballos()
        {
            return db.Zeballos;
        }

        // GET: api/Zeballoss/5
        [Authorize]
        [ResponseType(typeof(Zeballos))]
        public IHttpActionResult GetZeballos(int id)
        {
            Zeballos zeballos = db.Zeballos.Find(id);
            if (zeballos == null)
            {
                return NotFound();
            }

            return Ok(zeballos);
        }

        // PUT: api/Zeballoss/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZeballos(int id, Zeballos zeballos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zeballos.ZeballosID)
            {
                return BadRequest();
            }

            db.Entry(zeballos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZeballosExists(id))
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

        // POST: api/Zeballoss
        [Authorize]
        [ResponseType(typeof(Zeballos))]
        public IHttpActionResult PostZeballos(Zeballos zeballos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zeballos.Add(zeballos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zeballos.ZeballosID }, zeballos);
        }

        // DELETE: api/Zeballoss/5
        [Authorize]
        [ResponseType(typeof(Zeballos))]
        public IHttpActionResult DeleteZeballos(int id)
        {
            Zeballos zeballos = db.Zeballos.Find(id);
            if (zeballos == null)
            {
                return NotFound();
            }

            db.Zeballos.Remove(zeballos);
            db.SaveChanges();

            return Ok(zeballos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZeballosExists(int id)
        {
            return db.Zeballos.Count(e => e.ZeballosID == id) > 0;
        }
    }
}