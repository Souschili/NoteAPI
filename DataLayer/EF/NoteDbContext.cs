using Microsoft.EntityFrameworkCore;
using NoteServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EF
{
   public class NoteDbContext:DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NoteDbContext(DbContextOptions<NoteDbContext>options):base(options)
        {
            //потом убрать и применить миграцию
            Database.EnsureCreated();
        }

        //пишем данные для теста
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Note>().HasData(
                new Note {Id=1 ,userId=1,Title="First Note",Text="This is first Note!!",posted=DateTime.Now },
               new Note {Id=2, userId = 1, Title = "Second Note", Text = "This is second Note!!", posted = DateTime.Now }
                );
        }
    }
}
