using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Models
{
    [Table("Posicoes")] // define o nome da tabela
    public class Posicao
    {
        [Key] // chave primaria e auto incremento
        public int Id { get; set; }

        [Display(Name = "Nome")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar a Posição")] //Mensagem para quando o campo estiver nulo
        public string Nome { get; set; }

        public ICollection<Jogador> Jogadores { get; set; } //para chave estrangeira
    }
}
