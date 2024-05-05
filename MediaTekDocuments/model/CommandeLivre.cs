using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTekDocuments.model
{
    public class CommandeLivre
    {
       
        public string Auteur { get; }
        public string Collection { get; }

        public int Id { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Montant { get; set; }
        public int NombreExemplaires { get; set; }
        public string EtapeSuivi { get; set; }
        public string Isbn { get; set; }

        public CommandeLivre(int id, DateTime dateCommande, decimal montant, int nombreExemplaires, string collection, string etapeSuivi, string isbn, string auteur)
        {
            this.Id = id;
            this.DateCommande = dateCommande;
            this.Montant = montant;
            this.NombreExemplaires = nombreExemplaires;
            this.EtapeSuivi = etapeSuivi;
            this.Isbn = isbn;
            this.Collection = collection;
            this.Auteur = auteur;

        }
    }
}


