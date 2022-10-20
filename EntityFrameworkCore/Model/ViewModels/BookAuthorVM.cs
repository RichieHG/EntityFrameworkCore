using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class BookAuthorVM
    {
        public Fluent_BookAuthor BookAuthor { get; set; }
        public Fluent_Book Book { get; set; }
        public IEnumerable<Fluent_BookAuthor> BookAuthorList { get; set; }
        public IEnumerable<SelectListItem>  AuthorList { get; set; }
    }
}
