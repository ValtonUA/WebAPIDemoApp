using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class UserController : ApiController
    {
        IRepository<User> repo;

        public UserController(IRepository<User> repository)
        {
            repo = repository;
        }

        // GET api/user
        public IHttpActionResult Get()
        {
            var list = repo.GetAll();
            //list.Add(new Models.User { UserId = 2, Username = "Test error" });
            return Ok(list);
        }

        // GET api/user/5
        public IHttpActionResult Get(int id)
        {
            var user = repo.Get(id);
            //user.Username = "Test error";
            return Ok(repo.Get(id));
        }

        // POST api/user
        public IHttpActionResult Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //user = new User { Username = "Test error" };
            repo.Post(user);
            repo.Save();
            return Ok();
        }

        // PUT api/user
        public IHttpActionResult Put([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //user = new User { Username = "Test error" };
            repo.Put(user);
            repo.Save();
            return Ok();
        }

        // DELETE api/user/5
        public IHttpActionResult Delete(int id)
        {
            //id++; // Test error
            repo.Delete(id);
            repo.Save();
            return Ok();
        }
    }
}
