using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public partial class TypeRepas
    {
        public TypeRepas()
        {
            Repas = new HashSet<Repas>();
        }

        [Display(Name = "Identifiant")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [MaxLength(10)]
        [Required]
        public string Nom { get; set; }

        [Display(Name = "Repas")]
        public ICollection<Repas> Repas { get; set; }
    }
}
