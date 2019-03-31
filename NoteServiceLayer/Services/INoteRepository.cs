using NoteServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteServiceLayer.Services
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAll ();
        Task Add (Note note);
    }
}
