using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task.Server.Models;

namespace Task.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Amateurs, The (Moguls, The)", Year = 2004, Type = "Book", PictureUrl = "http://dummyimage.com/227x100.png/cc0000/ffffff" },
                new Book { Id = 2, Name = "Taming the Fire (Ukroshcheniye ognya)", Year = 2004, Type = "Book", PictureUrl = "http://dummyimage.com/178x100.png/cc0000/ffffff" },
                new Book { Id = 3, Name = "No Way Out", Year = 2006, Type = "Book", PictureUrl = "http://dummyimage.com/161x100.png/cc0000/ffffff" },
                new Book { Id = 4, Name = "Magnolia", Year = 1992, Type = "Book", PictureUrl = "http://dummyimage.com/209x100.png/ff4444/ffffff" },
                new Book { Id = 5, Name = "Blast", Year = 2003, Type = "Audiobook", PictureUrl = "http://dummyimage.com/157x100.png/cc0000/ffffff" },
                new Book { Id = 6, Name = "Amish Grace", Year = 1987, Type = "Audiobook", PictureUrl = "http://dummyimage.com/205x100.png/ff4444/ffffff" },
                new Book { Id = 7, Name = "Star Wars: Threads of Destiny", Year = 1988, Type = "Audiobook", PictureUrl = "http://dummyimage.com/125x100.png/ff4444/ffffff" },
                new Book { Id = 8, Name = "Octane", Year = 1993, Type = "Book", PictureUrl = "http://dummyimage.com/199x100.png/5fa2dd/ffffff" },
                new Book { Id = 9, Name = "Orfeu", Year = 2006, Type = "Book", PictureUrl = "http://dummyimage.com/161x100.png/cc0000/ffffff" },
                new Book { Id = 10, Name = "Barcelona", Year = 1992, Type = "Audiobook", PictureUrl = "http://dummyimage.com/173x100.png/cc0000/ffffff" },
                new Book { Id = 11, Name = "In Your Dreams (Dans tes rêves)", Year = 2006, Type = "Book", PictureUrl = "http://dummyimage.com/158x100.png/dddddd/000000" },
                new Book { Id = 12, Name = "Jackass Presents: Bad Grandpa .5", Year = 2003, Type = "Audiobook", PictureUrl = "http://dummyimage.com/134x100.png/5fa2dd/ffffff" },
                new Book { Id = 13, Name = "Year of the Comet", Year = 2011, Type = "Audiobook", PictureUrl = "http://dummyimage.com/249x100.png/ff4444/ffffff" },
                new Book { Id = 14, Name = "BFFs", Year = 2012, Type = "Audiobook", PictureUrl = "http://dummyimage.com/218x100.png/5fa2dd/ffffff" },
                new Book { Id = 15, Name = "Hungry for Change", Year = 1996, Type = "Book", PictureUrl = "http://dummyimage.com/166x100.png/ff4444/ffffff" },
                new Book { Id = 16, Name = "Carmen", Year = 1991, Type = "Book", PictureUrl = "http://dummyimage.com/138x100.png/ff4444/ffffff" },
                new Book { Id = 17, Name = "Time Regained (Temps retrouvé, Le)", Year = 2010, Type = "Audiobook", PictureUrl = "http://dummyimage.com/173x100.png/cc0000/ffffff" },
                new Book { Id = 18, Name = "Innocent Lies", Year = 2010, Type = "Book", PictureUrl = "http://dummyimage.com/218x100.png/dddddd/000000" },
                new Book { Id = 19, Name = "Pendulum", Year = 1994, Type = "Audiobook", PictureUrl = "http://dummyimage.com/138x100.png/5fa2dd/ffffff" },
                new Book { Id = 20, Name = "Always for Pleasure", Year = 1995, Type = "Book", PictureUrl = "http://dummyimage.com/103x100.png/5fa2dd/ffffff" },
                new Book { Id = 21, Name = "$5 a Day", Year = 1990, Type = "Book", PictureUrl = "http://dummyimage.com/242x100.png/5fa2dd/ffffff" },
                new Book { Id = 22, Name = "Rocketeer, The", Year = 2007, Type = "Book", PictureUrl = "http://dummyimage.com/213x100.png/cc0000/ffffff" },
                new Book { Id = 23, Name = "Theory of Everything, The", Year = 2005, Type = "Audiobook", PictureUrl = "http://dummyimage.com/203x100.png/dddddd/000000" },
                new Book { Id = 24, Name = "The Fat Albert Halloween Special", Year = 1992, Type = "Audiobook", PictureUrl = "http://dummyimage.com/164x100.png/ff4444/ffffff" },
                new Book { Id = 25, Name = "Drunks", Year = 2012, Type = "Book", PictureUrl = "http://dummyimage.com/177x100.png/ff4444/ffffff" },
                new Book { Id = 26, Name = "Take Me Out to the Ball Game", Year = 2012, Type = "Audiobook", PictureUrl = "http://dummyimage.com/137x100.png/dddddd/000000" },
                new Book { Id = 27, Name = "Stoning of Soraya M., The", Year = 2012, Type = "Book", PictureUrl = "http://dummyimage.com/226x100.png/dddddd/000000" },
                new Book { Id = 28, Name = "Delusion", Year = 2002, Type = "Audiobook", PictureUrl = "http://dummyimage.com/111x100.png/ff4444/ffffff" },
                new Book { Id = 29, Name = "Devil's Playground, The", Year = 2008, Type = "Audiobook", PictureUrl = "http://dummyimage.com/102x100.png/dddddd/000000" },
                new Book { Id = 30, Name = "Shotgun Stories", Year = 1999, Type = "Audiobook", PictureUrl = "http://dummyimage.com/153x100.png/cc0000/ffffff" },
                new Book { Id = 31, Name = "Dear White People", Year = 2005, Type = "Audiobook", PictureUrl = "http://dummyimage.com/161x100.png/cc0000/ffffff" },
                new Book { Id = 32, Name = "Hell's Highway: The True Story of Highway Safety Films", Year = 2002, Type = "Book", PictureUrl = "http://dummyimage.com/231x100.png/5fa2dd/ffffff" },
                new Book { Id = 33, Name = "Storm Center", Year = 1996, Type = "Audiobook", PictureUrl = "http://dummyimage.com/158x100.png/ff4444/ffffff" },
                new Book { Id = 34, Name = "Sniper", Year = 2000, Type = "Audiobook", PictureUrl = "http://dummyimage.com/217x100.png/cc0000/ffffff" },
                new Book { Id = 35, Name = "Girl with a Pearl Earring", Year = 1988, Type = "Book", PictureUrl = "http://dummyimage.com/135x100.png/ff4444/ffffff" },
                new Book { Id = 36, Name = "Defending Your Life", Year = 2003, Type = "Book", PictureUrl = "http://dummyimage.com/106x100.png/dddddd/000000" },
                new Book { Id = 37, Name = "Andrei Rublev (Andrey Rublyov)", Year = 1995, Type = "Audiobook", PictureUrl = "http://dummyimage.com/173x100.png/cc0000/ffffff" },
                new Book { Id = 38, Name = "Zero Charisma", Year = 2008, Type = "Book", PictureUrl = "http://dummyimage.com/246x100.png/dddddd/000000" },
                new Book { Id = 39, Name = "Secret of My Succe$s, The (a.k.a. The Secret of My Success)", Year = 2001, Type = "Book", PictureUrl = "http://dummyimage.com/233x100.png/ff4444/ffffff" },
                new Book { Id = 40, Name = "Fright Night", Year = 1999, Type = "Book", PictureUrl = "http://dummyimage.com/106x100.png/ff4444/ffffff" },
                new Book { Id = 41, Name = "Fox, The", Year = 2003, Type = "Audiobook", PictureUrl = "http://dummyimage.com/120x100.png/5fa2dd/ffffff" },
                new Book { Id = 42, Name = "Popatopolis", Year = 2011, Type = "Book", PictureUrl = "http://dummyimage.com/240x100.png/ff4444/ffffff" },
                new Book { Id = 43, Name = "Fate Is the Hunter", Year = 1999, Type = "Audiobook", PictureUrl = "http://dummyimage.com/176x100.png/ff4444/ffffff" },
                new Book { Id = 44, Name = "Sunday in the Country, A (Un dimanche à la campagne)", Year = 1994, Type = "Audiobook", PictureUrl = "http://dummyimage.com/100x100.png/5fa2dd/ffffff" },
                new Book { Id = 45, Name = "Deuces Wild", Year = 2004, Type = "Audiobook", PictureUrl = "http://dummyimage.com/190x100.png/ff4444/ffffff" },
                new Book { Id = 46, Name = "Gunless", Year = 1973, Type = "Book", PictureUrl = "http://dummyimage.com/140x100.png/dddddd/000000" },
                new Book { Id = 47, Name = "Camila", Year = 2008, Type = "Book", PictureUrl = "http://dummyimage.com/146x100.png/ff4444/ffffff" },
                new Book { Id = 48, Name = "Dark Forces (Harlequin)", Year = 2003, Type = "Audiobook", PictureUrl = "http://dummyimage.com/239x100.png/dddddd/000000" },
                new Book { Id = 49, Name = "Tarzan", Year = 1992, Type = "Audiobook", PictureUrl = "http://dummyimage.com/204x100.png/cc0000/ffffff" },
                new Book { Id = 50, Name = "Ghosts... of the Civil Dead", Year = 1991, Type = "Book", PictureUrl = "http://dummyimage.com/149x100.png/ff4444/ffffff" }
            );
        }
    }
}
