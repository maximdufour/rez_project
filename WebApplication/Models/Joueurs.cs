using System;
using System.Collections.Generic;

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

        public int Id { get; set; }
        public string Nom { get; set; }
        public int Solde { get; set; }
        public int? StatPerte { get; set; }
        public string Usager { get; set; }
        public string Mdp { get; set; }

        public ICollection<Repas> RepasAssistantNavigation { get; set; }
        public ICollection<Repas> RepasCookNavigation { get; set; }
        public ICollection<Repas> RepasVaissaileuxNavigation { get; set; }
        public ICollection<TransactionArgent> TransactionArgent { get; set; }
    }
}
