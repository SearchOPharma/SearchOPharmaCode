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
    public class DmnMedicinesController : ApiController
    {
        private searchopharmaEntities db = new searchopharmaEntities();

        // GET: api/DmnMedicines
        public IQueryable<DmnMedicine> GetDmnMedicines()
        {
            return db.DmnMedicines;
        }

        // GET: api/DmnMedicines/5
        [ResponseType(typeof(DmnMedicine))]
        public IHttpActionResult GetDmnMedicine(int id)
        {
            DmnMedicine dmnMedicine = db.DmnMedicines.Find(id);
            if (dmnMedicine == null)
            {
                return NotFound();
            }

            return Ok(dmnMedicine);
        }

        // PUT: api/DmnMedicines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDmnMedicine(int id, DmnMedicine dmnMedicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dmnMedicine.MedicineID)
            {
                return BadRequest();
            }

            db.Entry(dmnMedicine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DmnMedicineExists(id))
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

        // POST: api/DmnMedicines
        [ResponseType(typeof(DmnMedicine))]
        public IHttpActionResult PostDmnMedicine(DmnMedicine dmnMedicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DmnMedicines.Add(dmnMedicine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dmnMedicine.MedicineID }, dmnMedicine);
        }

        // DELETE: api/DmnMedicines/5
        [ResponseType(typeof(DmnMedicine))]
        public IHttpActionResult DeleteDmnMedicine(int id)
        {
            DmnMedicine dmnMedicine = db.DmnMedicines.Find(id);
            if (dmnMedicine == null)
            {
                return NotFound();
            }

            db.DmnMedicines.Remove(dmnMedicine);
            db.SaveChanges();

            return Ok(dmnMedicine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DmnMedicineExists(int id)
        {
            return db.DmnMedicines.Count(e => e.MedicineID == id) > 0;
        }
    }
}