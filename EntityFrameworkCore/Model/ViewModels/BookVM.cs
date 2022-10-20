using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class BookVM
    {
        public Fluent_Book Book { get; set; }
        public IEnumerable<SelectListItem>? PublisherList { get; set; }
    }
}
