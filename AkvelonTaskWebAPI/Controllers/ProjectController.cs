using AkvelonTaskWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext context;

        public ProjectController(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Getting list of all Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get()
        {
            return Ok(await context.Projects.ToListAsync());
        }

        /// <summary>
        /// adding a new project
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(ProjectClassDTO temp)
        {
            var newProject = new Project
            {
                Name = temp.Name,
                StartDate=temp.StartDate,
                EndDate=temp.EndDate,
                Status = temp.Status,
                Priority = temp.Priority
            };
            context.Projects.Add(newProject);
            await context.SaveChangesAsync();

            return Ok(await context.Projects.ToListAsync());
        }
        /// <summary>
        /// update project
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<List<Project>>> UpdateProject(int projectId, ProjectClassDTO request)
        {
            var dbHero = await context.Projects.FindAsync(projectId);
            if (dbHero == null)
                return BadRequest("Project is not found.");

            dbHero.Name = request.Name;
            dbHero.StartDate = request.StartDate;
            dbHero.EndDate = request.EndDate;
            dbHero.Priority = request.Priority;
            dbHero.Status = request.Status;

            await context.SaveChangesAsync();

            return Ok(await context.Projects.ToListAsync());
        }
        /// <summary>
        /// delete project from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Project>>> DeleteProject(int id)
        {
            var dbHero = await context.Projects.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            context.Projects.Remove(dbHero);
            await context.SaveChangesAsync();
            return Ok(await context.Projects.ToListAsync());
        }
    }
}
