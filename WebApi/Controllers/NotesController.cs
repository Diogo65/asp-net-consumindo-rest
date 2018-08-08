using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class NotesController : ApiController
    {
        NoteContext db = new NoteContext();

        [HttpGet]
        public List<Note> GetNotes()
        {
            return db.Notes.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetNotes(int id)
        {
            Note note = db.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        public IHttpActionResult PostNotes(Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = note.Id }, note);
        }

        [HttpPut]
        public IHttpActionResult PutNotes(int id, Note note)
        {
            if (db.Notes.Count(e => e.Id == id) == 0)
                return NotFound();

            db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteNotes(int id)
        {
            Note note = db.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            db.Notes.Remove(note);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
