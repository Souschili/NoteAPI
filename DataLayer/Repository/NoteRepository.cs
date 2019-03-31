using DataLayer.EF;
using Microsoft.EntityFrameworkCore;
using NoteServiceLayer.Models;
using NoteServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class NoteRepository : INoteRepository
    {
        private NoteDbContext _context ;

        public NoteRepository(NoteDbContext context)
        {
            _context = context;

        }

        public async Task Add (Note note)
        {
            await this._context.Notes.AddAsync(note);
            await this._context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAll ()
        {
            return await _context.Notes.ToListAsync();
        }
    }
}
