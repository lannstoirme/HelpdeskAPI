﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Bson;
using HelpdeskTicketing.Services;
using Microsoft.AspNetCore.Routing;

namespace HelpdeskTicketing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {


        // private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        //public UserController(ILogger<UserController> logger)
        //{
        //    _logger = logger;
        //}

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();


        [HttpGet("{Id}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }
        //public IEnumerable<User> Get()
        //{
        //    var client = new MongoClient("mongodb+srv://lannstoirme:Vienna1988!@cluster0.nwr3l.azure.mongodb.net/AsgardiaDB?retryWrites=true&w=majority");
        //    var database = client.GetDatabase("AsgardiaDB");
        //    var collection = database.GetCollection<User>("UserData");

        //    return collection.Find(s => s.NativeLanguage == "English").ToList();

        //}
    }
}