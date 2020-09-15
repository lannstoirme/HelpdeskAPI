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
    public class PosMessController : ControllerBase
    {
        private readonly PosMessService _posmessService;

        public PosMessController(PosMessService posmessService)
        {
            _posmessService = posmessService;
        }

        [HttpGet]
        public ActionResult Get() =>
           _posmessService.Get();


        [HttpGet("{Id}", Name = "GetPossitiveMessage")]
        public ActionResult Get(string Id)
        {
            var posmessage = _posmessService.Get(Id);

            if (posmessage == null)
            {
                return NotFound();
            }

            return posmessage;
        }
    }
}
