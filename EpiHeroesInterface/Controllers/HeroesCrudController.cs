using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EpiHeroesInterface.Models;

namespace EpiHeroesInterface.Controllers
{
    public class HeroesCrudController : ApiController
    {
        private EpiHeroesEntities db = new EpiHeroesEntities();

        // GET: api/HeroesCrud
        public IQueryable<Hero> GetHero()
        {
            return db.Hero;
        }

        // GET: api/HeroesCrud/5
        [ResponseType(typeof(Hero))]
        public IHttpActionResult GetHero(int id)
        {
            Hero hero = db.Hero.Find(id);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        // PUT: api/HeroesCrud/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHero(int id, Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hero.Id)
            {
                return BadRequest();
            }

            db.Entry(hero).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HeroesCrud
        [ResponseType(typeof(Hero))]
        public IHttpActionResult PostHero(Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hero.Add(hero);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HeroExists(hero.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hero.Id }, hero);
        }

        // DELETE: api/HeroesCrud/5
        [ResponseType(typeof(Hero))]
        public IHttpActionResult DeleteHero(int id)
        {
            Hero hero = db.Hero.Find(id);
            if (hero == null)
            {
                return NotFound();
            }

            db.Hero.Remove(hero);
            db.SaveChanges();

            return Ok(hero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeroExists(int id)
        {
            return db.Hero.Count(e => e.Id == id) > 0;
        }
    }
}