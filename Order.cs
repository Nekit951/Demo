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
        public Int32? Tovar { get; set; }

        [Column("Quantity")]
        public Int32? Quantity { get; set; }

        [Column("Summa")]
        public Decimal? Summa { get; set; }

        [Column("User")]
        public Int32? User { get; set; }

        [Column("Address")]
        public String Address { get; set; }
    }
}
