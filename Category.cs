using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WpfApp3.Models
{
   [Table("Category")]
   public class Category
    {
        [Key]
        [Column("Id")]
        public int id { get; set; }

        [Column("Category")]
        public string categoryName { get; set; }
    }
}
