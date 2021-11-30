using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Models
{
    [Table("Perfil")]
    public class Perfil
    {
        [Key]

        public int Id { get; set; }

        public int TimeId { get; set; }

        [ForeignKey("TimeId")]
        public Time Time { get; set; }

        public int EstatisticaId { get; set; }

        [ForeignKey("EstatisticaId")]
        public Estatistica Estatistica { get; set; }

        public int EscalacaoId { get; set; }

        [ForeignKey("EscalacaoId")]
        public Escalacao Escalacao { get; set; }

        public int PartidaId { get; set; }

        [ForeignKey("PartidaId")]
        public Partida Partida { get; set; }
    }
}
