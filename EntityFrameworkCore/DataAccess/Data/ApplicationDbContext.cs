using DataAccess.FluentConfig;
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

        public DbSet<Category> Category { get; set; }
        public DbSet<Genre> Genre { get; set; } 
        public  DbSet<Book> Book { get; set; }
        public  DbSet<Author> Author { get; set; }
        public  DbSet<Publisher> Publisher { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        public DbSet<Fluent_Book> Fluent_Book { get; set; }
        public DbSet<Fluent_Author> Fluent_Author { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publisher { get; set; }
        public DbSet<Fluent_BookDetails> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_BookAuthor> Fluent_BookAuthor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Here we configure Fluent API

            #region DataAnnotations and Fluent API

            //Category Table Name and Column Name
            modelBuilder.Entity<Category>().ToTable("tbl_Category");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("CategoryName");

            //Composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            #endregion

            modelBuilder.ApplyConfiguration(new Fluent_AuthorFluentConfig());
            modelBuilder.ApplyConfiguration(new Fluent_BookAuthorFluentConfig());
            modelBuilder.ApplyConfiguration(new Fluent_BookDetailsFluentConfig());
            modelBuilder.ApplyConfiguration(new Fluent_BookFluentConfig());
            modelBuilder.ApplyConfiguration(new Fluent_PublisherFluentConfig());
        }
    }
}
