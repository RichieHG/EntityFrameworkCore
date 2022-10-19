using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        public int Name { get; set; }
    }
}
