using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Repas
    {
        public Repas()
        {
            TransactionArgent = new HashSet<TransactionArgent>();
        }

        public int Id { get; set; }
        public int Repas1 { get; set; }
        public int Cook { get; set; }
        public int? Assistant { get; set; }
        public int Vaissaileux { get; set; }
        public DateTime DateRepas { get; set; }

        public Joueurs AssistantNavigation { get; set; }
        public Joueurs CookNavigation { get; set; }
        public TypeRepas Repas1Navigation { get; set; }
        public Joueurs VaissaileuxNavigation { get; set; }
        public ICollection<TransactionArgent> TransactionArgent { get; set; }

        public string Identity => $"{this.DateRepas} | {this.Repas1Navigation.Nom}";
    }
}