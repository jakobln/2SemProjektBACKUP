﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EFWebService;

namespace EFWebService.Controllers
{
    public class BilsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Bils
        public IQueryable<Bil> GetBil()
        {
            return db.Bil;
        }

        // GET: api/Bils/5
        [ResponseType(typeof(Bil))]
        public IHttpActionResult GetBil(int id)
        {
            Bil bil = db.Bil.Find(id);
            if (bil == null)
            {
                return NotFound();
            }

            return Ok(bil);
        }

        // PUT: api/Bils/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBil(int id, Bil bil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bil.BilID)
            {
                return BadRequest();
            }

            db.Entry(bil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BilExists(id))
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

        // POST: api/Bils
        [ResponseType(typeof(Bil))]
        public IHttpActionResult PostBil(Bil bil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bil.Add(bil);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bil.BilID }, bil);
        }

        // DELETE: api/Bils/5
        [ResponseType(typeof(Bil))]
        public IHttpActionResult DeleteBil(int id)
        {
            Bil bil = db.Bil.Find(id);
            if (bil == null)
            {
                return NotFound();
            }

            db.Bil.Remove(bil);
            db.SaveChanges();

            return Ok(bil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BilExists(int id)
        {
            return db.Bil.Count(e => e.BilID == id) > 0;
        }
    }
}