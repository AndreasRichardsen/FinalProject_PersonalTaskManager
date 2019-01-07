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
    public class TaskListController : ApiController
    {
        private BackEnd_TaskManagerContext db = new BackEnd_TaskManagerContext();

        // GET: api/TaskList
        public IQueryable<TaskList> GetTaskLists()
        {
            return db.TaskLists;
        }

        // GET: api/TaskList/5
        [ResponseType(typeof(TaskList))]
        public async Task<IHttpActionResult> GetTaskList(int id)
        {
            TaskList taskList = await db.TaskLists.FindAsync(id);
            if (taskList == null)
            {
                return NotFound();
            }

            return Ok(taskList);
        }

        // PUT: api/TaskList/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTaskList(int id, TaskList taskList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskList.Id)
            {
                return BadRequest();
            }

            db.Entry(taskList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskListExists(id))
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

        // POST: api/TaskList
        [ResponseType(typeof(TaskList))]
        public async Task<IHttpActionResult> PostTaskList(TaskList taskList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskLists.Add(taskList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = taskList.Id }, taskList);
        }

        // DELETE: api/TaskList/5
        [ResponseType(typeof(TaskList))]
        public async Task<IHttpActionResult> DeleteTaskList(int id)
        {
            TaskList taskList = await db.TaskLists.FindAsync(id);
            if (taskList == null)
            {
                return NotFound();
            }

            db.TaskLists.Remove(taskList);
            await db.SaveChangesAsync();

            return Ok(taskList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskListExists(int id)
        {
            return db.TaskLists.Count(e => e.Id == id) > 0;
        }
    }
}