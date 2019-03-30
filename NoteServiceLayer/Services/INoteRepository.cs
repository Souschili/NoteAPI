using NoteServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteServiceLayer.Services
{
    public interface INoteRepository
    {
        List<Note> GetAll();
        Task AddAsync(Note note);
    }
}
