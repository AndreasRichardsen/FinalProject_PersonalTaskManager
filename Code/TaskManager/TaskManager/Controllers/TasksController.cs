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

namespace TaskManager.Controllers
{
    public class TasksController : ApiController
    {
        private TaskManagerContext db = new TaskManagerContext();

        // GET: api/Tasks
        public IQueryable<TaskDTO> GetATasks()
        {
            var tasks = from t in db.ATasks
                        select new TaskDTO()
                        {
                            Id = t.Id,
                            TaskName = t.TaskName,
                            Category = t.Category,
                        };
            return tasks;
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(TaskDetailDTO))]
        public async Task<IHttpActionResult> GetATask(int id)
        {
            var task = await db.ATasks.Include(t => t.SubTasks).Select(t =>
            new TaskDetailDTO()
            {
                Id = t.Id,
                TaskName = t.TaskName,
                TaskInfo = t.TaskInfo,
                Category = t.Category,
                Favourite = t.Favourite,
                Done = t.Done,
                SubTasks = t.SubTasks.Select(st => st.Id).ToList()
            }).SingleOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
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

        // POST: api/Tasks
        [ResponseType(typeof(TaskDTO))]
        public async Task<IHttpActionResult> PostATask(ATask aTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ATasks.Add(aTask);
            await db.SaveChangesAsync();

            //db.Entry(aTask).Reference(x => x.SubTasks).Load();

            var sto = new TaskDTO()
            {
                Id = aTask.Id,
                TaskName = aTask.TaskName,
                Category = aTask.Category,
            };

            return CreatedAtRoute("DefaultApi", new { id = aTask.Id }, aTask);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(TaskDetailDTO))]
        public async Task<IHttpActionResult> DeleteATask(int id)
        {
            var aTask = await db.ATasks.FindAsync(id);
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