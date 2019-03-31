using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NoteServiceLayer.Models;

namespace NoteServiceLayer.Services
{
   public class NoteService : INoteService
    {
        private INoteRepository repository;
        public NoteService(INoteRepository repo)
        {
            this.repository = repo;
        }

        //добавить новость
        public async Task Add(Note note)
        {
            await this.repository.Add(note);
             
        }

        //получить все новости для теста контролера
        public Task<List<Note>> All()
        {
            return repository.GetAll();
        }

       
    }
}
