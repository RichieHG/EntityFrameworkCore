using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Fluent_Author
    {
        public int Author_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Location { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public virtual ICollection<Fluent_BookAuthor>? Fluent_BooksAuthors { get; set; }

    }
}
