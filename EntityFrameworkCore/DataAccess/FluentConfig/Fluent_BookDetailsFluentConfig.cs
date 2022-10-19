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
    public class Fluent_BookDetailsFluentConfig : IEntityTypeConfiguration<Fluent_BookDetails>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetails> modelBuilder)
        {
            //Here we configure Fluent API

            //Table and Column Name changes

            //Primary Keys
            modelBuilder.HasKey(bd => bd.BookDetails_Id);

            //OtherProperties
            modelBuilder.Property(bd => bd.NumberOfChapters).IsRequired();

            //Relations
        }
    }
}
