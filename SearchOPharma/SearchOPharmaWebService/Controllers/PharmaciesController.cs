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
using SearchOPharmaWebService.Models;

namespace SearchOPharmaWebService.Controllers
{
    public class PharmaciesController : ApiController
    {
        private searchopharmaEntities db = new searchopharmaEntities();

        // GET: api/Pharmacies
        public IQueryable<Pharmacy> GetPharmacies()
        {
            return db.Pharmacies;
        }

        // GET: api/Pharmacies/5
        [ResponseType(typeof(Pharmacy))]
        public IHttpActionResult GetPharmacy(int id)
        {
            Pharmacy pharmacy = db.Pharmacies.Find(id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return Ok(pharmacy);
        }

        // PUT: api/Pharmacies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPharmacy(int id, Pharmacy pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pharmacy.PharmacyID)
            {
                return BadRequest();
            }

            db.Entry(pharmacy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyExists(id))
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

        // POST: api/Pharmacies
        [ResponseType(typeof(Pharmacy))]
        public IHttpActionResult PostPharmacy(Pharmacy pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pharmacies.Add(pharmacy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pharmacy.PharmacyID }, pharmacy);
        }

        // DELETE: api/Pharmacies/5
        [ResponseType(typeof(Pharmacy))]
        public IHttpActionResult DeletePharmacy(int id)
        {
            Pharmacy pharmacy = db.Pharmacies.Find(id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            db.Pharmacies.Remove(pharmacy);
            db.SaveChanges();

            return Ok(pharmacy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PharmacyExists(int id)
        {
            return db.Pharmacies.Count(e => e.PharmacyID == id) > 0;
        }
    }
}