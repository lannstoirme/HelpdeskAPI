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
    public class MeetingController : ControllerBase
    {

        private readonly MeetingService _meetingService;

        public MeetingController(MeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public ActionResult<List<Meeting>> Get() =>
            _meetingService.Get();


        [HttpGet("{Id}", Name = "GetMeeting")]
        public ActionResult<Meeting> Get(string id)
        {
            var meeting = _meetingService.Get(id);

            if (meeting == null)
            {
                return NotFound();
            }

            return meeting;
        }

        [HttpPost]
        public ActionResult<Meeting> Create(Meeting meeting)
        {
            _meetingService.Create(meeting);

            return CreatedAtRoute("GetMeeting", new { id = meeting.Id.ToString() }, meeting);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(string id, Meeting meetingIn)
        {
            var meeting = _meetingService.Get(id);

            if (meeting == null)
            {
                return NotFound();
            }

            _meetingService.Update(id, meetingIn);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            var meeting = _meetingService.Get(id);

            if (meeting == null)
            {
                return NotFound();
            }

            _meetingService.Remove(meeting.Id);

            return NoContent();
        }

    }
}