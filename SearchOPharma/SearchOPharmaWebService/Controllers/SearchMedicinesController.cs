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
    public class SearchMedicinesController : ApiController
    {
        private searchopharmaEntities db = new searchopharmaEntities();

        // GET: api/SearchMedicines
        public IQueryable<SearchMedicine> GetSearchMedicines()
        {
            return db.SearchMedicines;
        }

        // GET: api/SearchMedicines/5
        [ResponseType(typeof(SearchMedicine))]
        public IHttpActionResult GetSearchMedicine(int id)
        {
            SearchMedicine searchMedicine = db.SearchMedicines.Find(id);
            if (searchMedicine == null)
            {
                return NotFound();
            }

            return Ok(searchMedicine);
        }

        // PUT: api/SearchMedicines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSearchMedicine(int id, SearchMedicine searchMedicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != searchMedicine.SearchID)
            {
                return BadRequest();
            }

            db.Entry(searchMedicine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchMedicineExists(id))
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

        // POST: api/SearchMedicines
        [ResponseType(typeof(SearchMedicine))]
        public IHttpActionResult PostSearchMedicine(SearchMedicine searchMedicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SearchMedicines.Add(searchMedicine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = searchMedicine.SearchID }, searchMedicine);
        }

        // DELETE: api/SearchMedicines/5
        [ResponseType(typeof(SearchMedicine))]
        public IHttpActionResult DeleteSearchMedicine(int id)
        {
            SearchMedicine searchMedicine = db.SearchMedicines.Find(id);
            if (searchMedicine == null)
            {
                return NotFound();
            }

            db.SearchMedicines.Remove(searchMedicine);
            db.SaveChanges();

            return Ok(searchMedicine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SearchMedicineExists(int id)
        {
            return db.SearchMedicines.Count(e => e.SearchID == id) > 0;
        }
    }
}