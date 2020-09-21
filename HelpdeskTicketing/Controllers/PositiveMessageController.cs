using System;
using System.Collections.Generic;
using System.Linq;
using HelpdeskTicketing.Services;
using Microsoft.AspNetCore.Mvc;
using static HelpdeskTicketing.Services.PositiveMessageService;

namespace HelpdeskTicketing.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PositiveMessageController : ControllerBase
    {
        private readonly PositiveMessageService _positivemessageService;

        public PositiveMessageController(PositiveMessageService positivemessageService)
        {

            _positivemessageService = positivemessageService;
            
        }

        [HttpGet]
        public ActionResult<List<PositiveMessages>> Get() =>
             _positivemessageService.Get();


        [HttpGet("{Id}", Name = "GetPositiveMessage")]
        public ActionResult<PositiveMessages> Get(string id)
        {
            var positivemessage = _positivemessageService.Get(id);

            if (positivemessage == null)
            {
                return NotFound();
            }

            return positivemessage;
        }
       

    }
}
