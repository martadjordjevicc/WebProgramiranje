
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Backend.Models
{
    [Table("Porudzbina")]
    public class Porudzbina{

        [Key]
        [Column("ID")]
        public int IDPorudzbine {get; set;}

        [Column("Hrana")]
        [MaxLength(255)]
        public string Hrana {get; set;}

        [Column("Pice")]
        [MaxLength(255)]
        public string Pice {get; set;}

        [JsonIgnore]
        public LetnjiBar Bar {get; set;}
    }
}