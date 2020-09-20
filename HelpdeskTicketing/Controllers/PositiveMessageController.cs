using System;
using System.Collections.Generic;
using System.Linq;
using HelpdeskTicketing.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<string> Get()
        {
            return new string[] { };
        }
        //public ActionResult Get()
        //{
        //    var positivemessage = _positivemessageService.Get();
        //
        //    if (positivemessage == null)
        //    {
        //        return NotFound();
        //    }

          //  return (ActionResult)positivemessage;
        //}

    }
}
