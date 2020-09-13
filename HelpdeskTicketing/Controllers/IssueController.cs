using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.AspNetCore.Routing;
using HelpdeskTicketing.Services;
using HelpdeskTicketing.Models;

namespace HelpdeskTicketing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssueController : ControllerBase
    {

        private readonly IssueService _issueService;

        public IssueController(IssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpGet]
        public ActionResult<List<Issue>> Get() =>
            _issueService.Get();


        [HttpGet("{Id}", Name = "GetIssue")]
        public ActionResult<Issue> Get(string id)
        {
            var issue = _issueService.Get(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

        [HttpPost]
        public ActionResult<Issue> Create(Issue issue)
        {
            _issueService.Create(issue);

            return CreatedAtRoute("GetIssue", new { id = issue.Id.ToString() }, issue);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(string id, Issue issueIn)
        {
            var issue = _issueService.Get(id);

            if (issue == null)
            {
                return NotFound();
            }

            _issueService.Update(id, issueIn);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            var issue = _issueService.Get(id);

            if (issue == null)
            {
                return NotFound();
            }

            _issueService.Remove(issue.Id);

            return NoContent();
        }
        
    }
}

