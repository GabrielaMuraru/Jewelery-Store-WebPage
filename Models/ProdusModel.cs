using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MagazinDeBijuteriiPROIECTFINAL.Models
{
    public class ProdusModel
    {
        [Key]
        public int ProdusId { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set;}
        public int Cantitate { get; set; }
    }

    public class ProdusContext : DbContext
    {
        public DbSet<ProdusModel> Produse { get; set; }
    }
}