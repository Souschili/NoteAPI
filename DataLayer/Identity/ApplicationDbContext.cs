using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Identity
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {

        // так мы получаем контекст нашего юзера а не айдентити юзера по дефолту (смутно пока понял в чем там разница)
        public new DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }
      

    }
}
