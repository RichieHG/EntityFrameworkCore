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
    public class Fluent_BookFluentConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            //Here we configure Fluent API

            //Table and Column Name changes

            //Primary Keys
            modelBuilder.HasKey(b => b.Book_Id);

            //OtherProperties
            modelBuilder.Property(b => b.Title).IsRequired();
            modelBuilder.Property(b => b.Price).IsRequired();
            modelBuilder.Property(b => b.ISBN).IsRequired().HasMaxLength(15);


            //Relations

            // One to One Book/BookDetails
            modelBuilder.HasOne(x => x.Fluent_BookDetails)
                            .WithOne(z => z.Fluent_Book)
                            .HasForeignKey<Fluent_Book>(y => y.BookDetails_Id);

            //One to Many Book/Publisher
            modelBuilder.HasOne(x => x.Fluent_Publisher)
                            .WithMany(z => z.Fluent_Books)
                            .HasForeignKey(y => y.Publisher_Id);
        }
    }
}
