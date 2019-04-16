using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiraDoPrego.Api.Model
{
    [Table("prestadores")]
    public class Prestador
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("nome")]
        public string nome { get; set; }
        [Column("latitude")]
        public string latitude { get; set; }
        [Column("longitude")]
        public string longitude { get; set; }
        [Column("horario")]
        public string horario { get; set; }
        [Column("telefone")]
        public string telefone { get; set; }
    }
}
