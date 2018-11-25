using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public partial class Joueurs
    {
        public Joueurs()
        {
            RepasAssistantNavigation = new HashSet<Repas>();
            RepasCookNavigation = new HashSet<Repas>();
            RepasVaissaileuxNavigation = new HashSet<Repas>();
            TransactionArgent = new HashSet<TransactionArgent>();
        }

        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Display(Name = "Solde ($)")]
        public int Solde { get; set; }

        [Display(Name = "Statistique de perte ($)")]
        public int? StatPerte { get; set; }

        [Display(Name = "Usager")]
        public string Usager { get; set; }

        [Display(Name = "Mot de passe")]
        public string Mdp { get; set; }

        [Display(Name = "L'assistant du repas")]
        public ICollection<Repas> RepasAssistantNavigation { get; set; }

        [Display(Name = "Le cook du repas")]
        public ICollection<Repas> RepasCookNavigation { get; set; }

        [Display(Name = "Le vaissaileux du repas")]
        public ICollection<Repas> RepasVaissaileuxNavigation { get; set; }

        [Display(Name = "Transaction d'argent")]
        public ICollection<TransactionArgent> TransactionArgent { get; set; }
    }
}
