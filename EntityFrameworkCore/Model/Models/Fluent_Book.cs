using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Fluent_Book
    {
        public int Book_Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public int? BookDetails_Id { get; set; }
        public int Publisher_Id { get; set; }
        public Fluent_BookDetails? Fluent_BookDetails { get; set; }
        public Fluent_Publisher Fluent_Publisher { get; set; }
        public virtual ICollection<Fluent_BookAuthor>? Fluent_BooksAuthors { get; set; }

    }
}
