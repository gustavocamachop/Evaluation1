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
using apiEvalu.Models;

namespace apiEvalu.Content
{
    public class GradesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Grades
        public IQueryable<Grades> GetGrades()
        {
            return db.Grades;
        }

        // GET: api/Grades/5
        [ResponseType(typeof(Grades))]
        public IHttpActionResult GetGrades(int id)
        {
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return NotFound();
            }

            return Ok(grades);
        }

        // PUT: api/Grades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrades(int id, Grades grades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grades.NID)
            {
                return BadRequest();
            }

            db.Entry(grades).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradesExists(id))
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

        // POST: api/Grades
        [ResponseType(typeof(Grades))]
        public IHttpActionResult PostGrades(Grades grades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grades.Add(grades);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = grades.NID }, grades);
        }

        // DELETE: api/Grades/5
        [ResponseType(typeof(Grades))]
        public IHttpActionResult DeleteGrades(int id)
        {
            Grades grades = db.Grades.Find(id);
            if (grades == null)
            {
                return NotFound();
            }

            db.Grades.Remove(grades);
            db.SaveChanges();

            return Ok(grades);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradesExists(int id)
        {
            return db.Grades.Count(e => e.NID == id) > 0;
        }
    }
}