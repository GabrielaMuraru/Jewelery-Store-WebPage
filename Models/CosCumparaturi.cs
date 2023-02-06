using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Languages;

namespace MagazinBijuteri.Models
{
    public class CosCumparaturi
    {
        [Key]
        public int ProdusId { get; set; }
        [Display(Name = "Descriere", ResourceType = typeof(Resource))]
        public string Descriere { get; set; }
        [Display(Name = "Denumire", ResourceType = typeof(Resource))]
        public string Denumire { get; set; }
        [Display(Name = "Cantitate", ResourceType = typeof(Resource))]
        public int Cantitate { get; set; }
        [Display(Name = "Pret", ResourceType = typeof(Resource))]
        public double Pret { get; set; }

    }

    public class CosCumparaturiDbContext : DbContext
    { 
        public DbSet<CosCumparaturi> Cos { get; set; }
    }

}