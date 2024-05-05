using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTekDocuments.model
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Montant { get; set; }
        public int NombreExemplaires { get; set; }
        public string EtapeSuivi { get; set; }
        public string Isbn { get; set; }  

        public Commande(int id, DateTime dateCommande, decimal montant, int nombreExemplaires, string etapeSuivi, string isbn)
        {
            this.Id = id;
            this.DateCommande = dateCommande;
            this.Montant = montant;
            this.NombreExemplaires = nombreExemplaires;
            this.EtapeSuivi = etapeSuivi;
            this.Isbn = isbn;
        }
    }
}


