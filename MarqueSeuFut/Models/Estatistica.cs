using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Models
{
    [Table("Estatisticas")]
    public class Estatistica
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "Partida")] // palavra que vai ser exibida em nossa tela
        public int PartidaId { get; set; }

        [ForeignKey("PartidaId")]
        public Partida Partida { get; set; } //para chave estrangeira

        [Display(Name = "Gols Feitos")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar a quantidade de Gols Feitos!")] //Mensagem para quando o campo estiver nulo
        public int GolsF { get; set; }

        [Display(Name = "Gols Sofridos")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar a quantidade de Gols Sofridos!")] //Mensagem para quando o campo estiver nulo
        public int GolsS { get; set; }


    }
}
