using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentConfig
{
    public class Fluent_BookAuthorFluentConfig : IEntityTypeConfiguration<Fluent_BookAuthor>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthor> modelBuilder)
        {
            //Here we configure Fluent API

            //Table and Column Name changes

            //Primary Keys
            modelBuilder.HasKey(ba => new { ba.Author_Id, ba.Book_Id });
            
            //OtherProperties

            //Relations
            modelBuilder.HasOne(x => x.Fluent_Book)
                            .WithMany(z => z.Fluent_BooksAuthors)
                            .HasForeignKey(x => x.Book_Id);
            modelBuilder.HasOne(x => x.Fluent_Author)
                            .WithMany(z => z.Fluent_BooksAuthors)
                            .HasForeignKey(x => x.Author_Id);
        }
    }
}
