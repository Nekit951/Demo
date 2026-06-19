using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp3.Models
{
    [Table("Tovar")]
    public class Tovar
    {
        [Key]
        [Column("Id")]
        public int id { get; set; }

        [Column("Name")]
        public String name { get; set; }

        [Column("Category")]
        public Int32? category { get; set; }

        [Column("Price")]
        public Decimal? price { get; set; }

        [Column("Quantity")]
        public Int32? quantity { get; set; }
    }
}
