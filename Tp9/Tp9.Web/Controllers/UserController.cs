using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tp9.Entities;
using Tp9.Web.Database;

namespace Tp9.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext db;

        public UserController(AppDbContext context)
        {
            this.db = context;
        }

        [HttpGet("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<User> Authenticate(
            [FromQuery(Name = "login")] String login, 
            [FromQuery(Name = "password")] String password)
        {
            return this.db.Users.FirstOrDefault(x => x.Login.Equals(login) && x.Password.Equals(password));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<User>> List()
        {
            return this.db.Users.ToList();
        }
    }
}
