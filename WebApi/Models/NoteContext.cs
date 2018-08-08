using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class NoteContext : DbContext
    {
        public NoteContext() : base("name=CursoLocal")
        {

        }

        public DbSet<Note> Notes { get; set; }
    }
}