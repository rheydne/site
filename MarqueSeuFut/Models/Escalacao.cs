using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Models
{
    [Table("Escalacoes")]
    public class Escalacao
    {
        [Key]
        public int Id { get; set; }

        public int TimeId { get; set; } //para chave estrangeira

        [ForeignKey("TimeId")]
        public Time Time { get; set; } //para chave estrangeira

        public int JogadorId { get; set; } //para chave estrangeira

        [ForeignKey("JogadorId")]
        public Jogador Jogador { get; set; } //para chave estrangeira

        public bool IsTItular { get; set; }
    }
}
