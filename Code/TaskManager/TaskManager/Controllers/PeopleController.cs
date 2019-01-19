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
using TaskManager.Models;
using TaskManager.Controllers;

namespace TaskManager.Controllers
{
    public class PeopleController : ApiController
    {
        //LINQ: Specify the data source
        private TaskManagerContext db = new TaskManagerContext();

        // GET: api/People
        public IQueryable<PersonDTO> GetPeople()
        {
            //LINQ: Define the query expression
            var people = from p in db.People
                         select new PersonDTO()
                         {
                             Id = p.Id,
                             UserName = p.UserName
                         };
            //LINQ: Execute the query
            return people;
        }

        // GET: api/People/5
        [ResponseType(typeof(PersonDetailDTO))]
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            var person = await db.People.Include(p => p.Tasks).Select(p =>
            new PersonDetailDTO()
            {
                Id = p.Id,
                UserName = p.UserName,
                FamilyName = p.FamilyName,
                GivenName = p.GivenName,
                Email = p.Email,
                Tasks = p.Tasks.Select(t => t.Id).ToList()
            }).SingleOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(int id, PersonDetailDTO person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        [ResponseType(typeof(PersonDTO))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);
            await db.SaveChangesAsync();

            //db.Entry(person).Reference(x => x.Tasks).Load();

            var sto = new PersonDTO()
            {
                Id = person.Id,
                UserName = person.UserName
            };

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(PersonDetailDTO))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            var person = await db.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
        }
    }
}