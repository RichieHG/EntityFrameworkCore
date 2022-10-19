using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<Category> Category { get; set; }
        public DbSet<Genre> Genre { get; set; } 
        public  DbSet<Book> Book { get; set; }
        public  DbSet<Author> Author { get; set; }
        public  DbSet<Publisher> Publisher { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Here we configure Fluent API

            //Composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });
        }
    }
}
