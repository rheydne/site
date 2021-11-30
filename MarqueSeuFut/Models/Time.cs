using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Models
{
    [Table("Times")] // define o nome da tabela
    public class Time
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar o nome")] //Mensagem para quando o campo estiver nulo
        public string Nome { get; set; }

        [Display(Name = "Localização")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar a localização")] //Mensagem para quando o campo estiver nulo
        public string Localizacao { get; set; }

        [Display(Name = "Ano de Fundacao")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar o ano de fundação")] //Mensagem para quando o campo estiver nulo
        public int AnoFundacao { get; set; }

        public string Escudo { get; set; }

        public string Descricao { get; set; }

        public ICollection<Jogador> Jogadores { get; set; } //para chave estrangeira

        public ICollection<Escalacao> Escalacoes { get; set; } //para chave estrangeira

        public ICollection<Estatistica> Estatisticas { get; set; } //para chave estrangeira

        public ICollection<Pesquisa> Pesquisa { get; set; } //para chave estrangeira

    }
}
