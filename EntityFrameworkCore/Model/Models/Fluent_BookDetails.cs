using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Fluent_BookDetails
    {
        public int BookDetails_Id { get; set; }
        public int NumberOfChapters { get; set; }
        public int? NumberOfPages { get; set; }
        public double? Weight { get; set; }
        public Fluent_Book Fluent_Book { get; set; }
    }
}
