using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tp9.Entities;
using Tp9.Web.Database;

namespace Tp9.Controllers
{
    [Route("api/tweets")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly AppDbContext db;

        public TweetController(AppDbContext context)
        {
            this.db = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Tweet>> List()
        {
            return this.db.Tweets.Include(x => x.User).ToList();
        }

        [HttpGet("filtered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Tweet>> FilteredList(
            [FromQuery(Name = "username")] String username,
            [FromQuery(Name = "dateTime")] DateTime? dateTime)
        {
            IEnumerable<Tweet> result = new List<Tweet>();
            if (!String.IsNullOrEmpty(username) && dateTime != null)
            {
                result = this.db.Tweets.Include(x => x.User).Where(x => x.User.Login.Equals(username) && DateTime.Compare(x.CreatedAt, dateTime.Value) < 1).ToList();
            }
            else if (!String.IsNullOrEmpty(username))
            {
                result = this.db.Tweets.Include(x => x.User).Where(x => x.User.Login.Equals(username)).ToList();
            }
            else if (dateTime != null)
            {
                result = this.db.Tweets.Include(x => x.User).Where(x => DateTime.Compare(x.CreatedAt, dateTime.Value) < 1).ToList();
            }
            else
            {
                result = this.db.Tweets.Include(x => x.User);
            }

            return result.ToList();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Tweet> Create([FromBody] Tweet item)
        {
            this.db.Tweets.Add(item);
            this.db.SaveChanges();
            return CreatedAtAction(nameof(Create), new { item.Id }, item);
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<Item> GetItem(string id)
        //{
        //    Item item = tweetRepository.Get(id);

        //    if (item == null)
        //        return NotFound();

        //    return item;
        //}

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult Edit([FromBody] Item item)
        //{
        //    try
        //    {
        //        tweetRepository.Update(item);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Error while editing item");
        //    }
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult Delete(string id)
        //{
        //    Item item = tweetRepository.Remove(id);

        //    if (item == null)
        //        return NotFound();

        //    return Ok();
        //}
    }
}
