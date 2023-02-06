using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Languages;

namespace MagazinBijuteri.Models
{
    public class UtilizatorModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nume", ResourceType = typeof(Resource))]
        public string Nume { get; set; }
        [Display(Name = "Prenume", ResourceType = typeof(Resource))]
        public string Prenume { get; set; }
        [Display(Name = "Username", ResourceType = typeof(Resource))]
        public string Username { get; set; }
        [Display(Name = "Parola", ResourceType = typeof(Resource))]
        public string Parola { get; set; }
    }

    public class UtilizatorDbContext : DbContext
    { 
        public DbSet<UtilizatorModel> Utilizatori { get; set; }

        public System.Data.Entity.DbSet<MagazinBijuteri.Models.CosCumparaturi> CosCumparaturis { get; set; }

        public System.Data.Entity.DbSet<MagazinDeBijuteriiPROIECTFINAL.Models.ProdusModel> ProdusModels { get; set; }
    }

}