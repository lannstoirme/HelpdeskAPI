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
    public class ResponseController : ControllerBase
    {

        private readonly ResponseService _responseService;

        public ResponseController(responseService responseService)
        {
            _responseService = responseService;
        }

        [HttpGet]
        public ActionResult<List<Response>> Get() =>
            _responseService.Get();


        [HttpGet("{Id}", Name = "GetResponse")]
        public ActionResult<Response> Get(string id)
        {
            var response = _responseService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        [HttpPost]
        public ActionResult<Response> Create(Response response)
        {
            _issueService.Create(response);

            return CreatedAtRoute("GetResponse", new { id = response.Id.ToString() }, response);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(string id, Response responseIn)
        {
            var response = _responseService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            _responseService.Update(id, responseIn);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            var response = _responseService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            _responseService.Remove(issue.Id);

            return NoContent();
        }

    }
}