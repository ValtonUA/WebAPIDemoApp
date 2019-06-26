using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class CardController : ApiController
    {
        IRepository<Card> repo;

        public CardController(IRepository<Card> repository)
        {
            repo = repository;
        }

        // GET api/Card
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        // GET api/Card/5
        public IHttpActionResult Get(int id)
        {
            return Ok(repo.Get(id));
        }

        // POST api/Card
        public IHttpActionResult Post([FromBody]Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Post(card);
            repo.Save();
            return Ok();
        }

        // PUT api/Card
        public IHttpActionResult Put([FromBody]Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Put(card);
            repo.Save();
            return Ok();
        }

        // DELETE api/Card/5
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(id);
            repo.Save();
            return Ok();
        }
    }
}
