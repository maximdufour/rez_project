using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public partial class TransactionArgent
    {
        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Display(Name = "Montant ($)")]
        public int Montant { get; set; }

        [Display(Name = "Joueur")]
        public int Joueur { get; set; }

        [Display(Name = "Repas")]
        public int? Repas { get; set; }

        [Display(Name = "Joueur")]
        public Joueurs JoueurNavigation { get; set; }

        [Display(Name = "Repas")]
        public Repas RepasNavigation { get; set; }
    }
}
