using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiraDoPrego.Api.Model
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("login")]
        public string login { get; set; }
        [Column("password")]
        public string password { get; set; }
    }
}
