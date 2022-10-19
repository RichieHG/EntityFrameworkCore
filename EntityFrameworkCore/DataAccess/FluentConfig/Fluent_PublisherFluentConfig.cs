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
    public class Fluent_PublisherFluentConfig : IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
        {
            //Here we configure Fluent API

            //Table and Column Name changes

            //Primary Keys
            modelBuilder.HasKey(x => x.Publisher_Id);

            //OtherProperties
            modelBuilder.Property(x => x.Name).IsRequired();
            modelBuilder.Property(x => x.Location).IsRequired();
        }
    }
}
