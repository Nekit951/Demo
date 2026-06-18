using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp3.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("Id")]
        public int id { get; set; }

        [Column("Name")]
        public String Name { get; set; }

        [Column("Pass")]
        public String Pass { get; set; }
    }
}
