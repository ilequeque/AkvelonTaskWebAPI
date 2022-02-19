using AkvelonTaskWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DataContext context;

        public TaskController(DataContext context)
        {
            this.context= context;
        }
        /// <summary>
        /// gets all tasks in database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get()
        {
            return Ok(await context.Tasks.ToListAsync());
        }
        /// <summary>
        /// gets tasks of specific project by its Id numbers
        /// </summary>
        /// <param name="projId"></param>
        /// <returns></returns>
        [HttpGet("{projId}")]
        public async Task<ActionResult<List<TaskClass>>> Get(int projId)
        {
            var temp = await context.Tasks.
                Where(c => c.ProjectId == projId).ToListAsync();

            return temp;
        }
        /// <summary>
        /// adding a new task to project
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<TaskClass>>> Create(CreateClassDTO request)
        {
            var localproj = await context.Projects.FindAsync(request.ProjectId);
            if (localproj == null)
                return NotFound();

            var newTask = new TaskClass
            {
                Name = request.Name,
                Description = request.Description,
                Status = request.Status,
                Priority = request.Priority,
                Project = localproj
            };

            context.Tasks.Add(newTask);
            await context.SaveChangesAsync();

            return await Get(request.ProjectId);
        }

        /// <summary>
        /// update task
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<List<TaskClass>>> UpdateTask(int id, CreateClassDTO request)
        {
            var dbHero = await context.Tasks.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Task or Project is not found.");

            dbHero.Name = request.Name;
            dbHero.Description = request.Description;
            dbHero.Priority = request.Priority;
            dbHero.Status = request.Status;
            
            await context.SaveChangesAsync();

            return Ok(await context.Tasks.ToListAsync());
        }

        /// <summary>
        /// delete project from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaskClass>>> DeleteTask(int id)
        {
            var dbHero = await context.Tasks.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            context.Tasks.Remove(dbHero);
            await context.SaveChangesAsync();
            return Ok(await context.Tasks.ToListAsync());
        }
    }
}
