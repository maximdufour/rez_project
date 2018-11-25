using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public partial class Repas
    {
        public Repas()
        {
            TransactionArgent = new HashSet<TransactionArgent>();
        }

        [Display(Name = "Identifiant")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Type de repas")]
        [Required]
        public int Repas1 { get; set; }

        [Display(Name = "Cook")]
        [Required]
        public int Cook { get; set; }

        [Display(Name = "L'assistant")]
        public int? Assistant { get; set; }

        [Display(Name = "Vaissaileux")]
        [Required]
        public int Vaissaileux { get; set; }

        [Display(Name = "Date du repas")]
        [Required]
        public DateTime DateRepas { get; set; }

        [Display(Name = "Assistant")]
        public Joueurs AssistantNavigation { get; set; }

        [Display(Name = "Cook")]
        public Joueurs CookNavigation { get; set; }

        [Display(Name = "Type de repas")]
        public TypeRepas Repas1Navigation { get; set; }

        [Display(Name = "Vaissaileux")]
        public Joueurs VaissaileuxNavigation { get; set; }

        [Display(Name = "Transactions d'argent")]
        public ICollection<TransactionArgent> TransactionArgent { get; set; }

        [Display(Name = "Repas")]
        public string Identity => $"{this.DateRepas} | {this.Repas1Navigation.Nom}";
    }
}