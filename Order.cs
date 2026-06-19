using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp3.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Column("Id")]
        public int id { get; set; }

        [Column("Tovar")]
        public Int32? tovar { get; set; }

        [Column("Quantity")]
        public Int32? quantity { get; set; }

        [Column("Summa")]
        public Decimal? summa { get; set; }

        [Column("User")]
        public Int32? user { get; set; }

        [Column("Address")]
        public String address { get; set; }
    }
}
