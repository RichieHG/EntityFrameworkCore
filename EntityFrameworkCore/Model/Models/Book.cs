using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(15)]
        public string ISBN { get; set; }
        [Required]
        public double Price { get; set; }

        [ForeignKey("BookDetails")]
        public int BookDetails_Id { get; set; }

        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public BookDetails BookDetails { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
