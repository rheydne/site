using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Models
{
    [Table("Partidas")]
    public class Partida
    {
        [Key]

        public int Id { get; set; }


        [Display(Name = "Data")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar a Data!")] //Mensagem para quando o campo estiver nulo
        public DateTime Data { get; set; }


        [Display(Name = "Quadra")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar a Quadra da Partida!")] //Mensagem para quando o campo estiver nulo
        public string Quadra { get; set; }


        [Display(Name = "Cidade")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar a Cidade da Partida")] //Mensagem para quando o campo estiver nulo
        public string Cidade { get; set; }


        [Display(Name = "Time Casa")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar o time da casa!")] //Mensagem para quando o campo estiver nulo
        public int TimeCasaId { get; set; }

        [ForeignKey("TimeCasaId")]

        public Time TimeCasa { get; set; }

        [Display(Name = "Time Visitante")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar o time visitante!")] //Mensagem para quando o campo estiver nulo
        public int TimeVisitanteId { get; set; }

        [ForeignKey("TimeVisitanteId")]

        public Time TimeVisitante { get; set; }


    }
}
