using NoteServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteServiceLayer.Services
{
    public interface INoteService
    {
        List<Note>All();
        Task Add(Note note);

    }
}
