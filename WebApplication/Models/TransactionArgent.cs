using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class TransactionArgent
    {
        public int Id { get; set; }
        public int Montant { get; set; }
        public int Joueur { get; set; }
        public int? Repas { get; set; }

        public Joueurs JoueurNavigation { get; set; }
        public Repas RepasNavigation { get; set; }
    }
}
