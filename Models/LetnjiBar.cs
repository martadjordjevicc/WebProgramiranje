using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Backend.Models
{

    [Table("LetnjiBar")]
    public class LetnjiBar
    {
        [Key]
        [Column("ID")]
        public int IDBara {get; set;}
        
        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv {get; set;}

        [Column("Adresa")]

        public string Adresa {get; set;}

        [Column("Kapacitet")]
        public int Kapacitet {get; set;}


        public virtual List<Porudzbina> Porudzbine {get; set;}
        public virtual List<Lezaljka> Lezaljke {get; set;}


    }

}