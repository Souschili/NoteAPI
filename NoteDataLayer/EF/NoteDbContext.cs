using Microsoft.EntityFrameworkCore;
using NoteServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteDataLayer.EF
{
    public class NoteDbContext : DbContext
    {
        DbSet<Note> Notes {get;set;}

        public NoteDbContext(DbContextOptions<NoteDbContext> options):base(options){}

        //для теста лепим какието данные
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(
                new Note { Id=1,userId=1,Title="First",Text="This is test 1 news",posted=DateTime.Now },
                new Note { Id = 2, userId = 1, Title = "Second", Text = "This is test 2 news", posted = DateTime.Now }
                );
        }
    }
}
