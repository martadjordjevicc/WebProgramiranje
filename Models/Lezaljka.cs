using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    [Table("Lezaljka")]
    public class Lezaljka
    {
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        [Column("BroJLezaljke")]
        public int BrojLezaljke {get; set;}

        [Column("Tip")]
        [MaxLength(255)]
        public string Tip {get; set;}

        [Column("Ime")]
        [MaxLength(255)]
        public string Ime {get; set;}

        [Column("Prezime")]
        [MaxLength(255)]
        public string Prezime {get; set;}

        //[Column("Porudzbina")]
       // public Porudzbina Porudzbina {get; set;}

       [JsonIgnore]
       public LetnjiBar Bar {get; set;}
    }

}