using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BackEnd_TaskManager.Models;

namespace BackEnd_TaskManager.Controllers
{
    public class ATaskController : ApiController
    {
        private BackEnd_TaskManagerContext db = new BackEnd_TaskManagerContext();

        // GET: api/ATask
        public IQueryable<ATask> GetATasks()
        {
            return db.ATasks;
        }

        // GET: api/ATask/5
        [ResponseType(typeof(ATask))]
        public async Task<IHttpActionResult> GetATask(int id)
        {
            ATask aTask = await db.ATasks.FindAsync(id);
            if (aTask == null)
            {
                return NotFound();
            }

            return Ok(aTask);
        }

        // PUT: api/ATask/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutATask(int id, ATask aTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aTask.Id)
            {
                return BadRequest();
            }

            db.Entry(aTask).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ATaskExists(id))
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

        // POST: api/ATask
        [ResponseType(typeof(ATask))]
        public async Task<IHttpActionResult> PostATask(ATask aTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ATasks.Add(aTask);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aTask.Id }, aTask);
        }

        // DELETE: api/ATask/5
        [ResponseType(typeof(ATask))]
        public async Task<IHttpActionResult> DeleteATask(int id)
        {
            ATask aTask = await db.ATasks.FindAsync(id);
            if (aTask == null)
            {
                return NotFound();
            }

            db.ATasks.Remove(aTask);
            await db.SaveChangesAsync();

            return Ok(aTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ATaskExists(int id)
        {
            return db.ATasks.Count(e => e.Id == id) > 0;
        }
    }
}