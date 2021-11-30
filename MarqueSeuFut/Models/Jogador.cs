using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Models
{
    [Table("Jogadores")]
    public class Jogador
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome:")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar o jogador")] //Mensagem para quando o campo estiver nulo
        public string Nome { get; set; }

        [Display(Name = "Número:")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar o número")] //Mensagem para quando o campo estiver nulo
        public int Numero { get; set; }

        public int PosicaoId { get; set; } //para chave estrangeira

        [ForeignKey("PosicaoId")]
        public Posicao Posicao { get; set; } //para chave estrangeira

        public int TimeId { get; set; } //para chave estrangeira

        [ForeignKey("TimeId")]
        public Time Time { get; set; } //para chave estrangeira

        public ICollection<Escalacao> Escalacoes { get; set; } //para chave estrangeira
    }
}
