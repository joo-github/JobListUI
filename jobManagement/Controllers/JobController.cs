using JobBL;
using JobModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JobManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly BL _bl;

        public JobController()
        {
            _bl = new BL();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetAllJobs()
        {
            var jobs = _bl.GetAllJobs();
            return Ok(jobs);
        }

        [HttpGet("{title}")]
        public ActionResult<Job> GetJobByTitle(string title)
        {
            var job = _bl.GetJobByTitle(title);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost]
        public ActionResult AddNewJob([FromBody] Job newJob)
        {
            if (newJob == null)
            {
                return BadRequest();
            }
            _bl.AddNewJob(newJob);
            return CreatedAtAction(nameof(GetJobByTitle), new { title = newJob.JobTitle }, newJob);
        }

        [HttpPatch("{title}")]
        public ActionResult UpdateJob(string title, [FromBody] Job updatedJob)
        {
            var existingJob = _bl.GetJobByTitle(title);
            if (existingJob == null)
            {
                return NotFound();
            }

            updatedJob.JobTitle = title;
            _bl.UpdateJob(updatedJob);
            return NoContent();
        }

        [HttpDelete("{title}")]
        public ActionResult DeleteJob(string title)
        {
            var existingJob = _bl.GetJobByTitle(title);
            if (existingJob == null)
            {
                return NotFound();
            }

            _bl.DeleteJob(title);
            return NoContent();
        }
    }
}
