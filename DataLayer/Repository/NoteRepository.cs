using DataLayer.EF;
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

        public async Task AddAsync(Note note)
        {
           await _context.AddAsync(note);
           await _context.SaveChangesAsync();
        
        }

        public List<Note> GetAll()
        {
            // все записи пока что без привязки к юзеру
            return _context.Notes.ToList();
        }
    }
}
