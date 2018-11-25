using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class TypeRepas
    {
        public TypeRepas()
        {
            Repas = new HashSet<Repas>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public ICollection<Repas> Repas { get; set; }
    }
}
