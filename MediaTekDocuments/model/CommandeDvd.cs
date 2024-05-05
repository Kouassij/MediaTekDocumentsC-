using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTekDocuments.model
{
	public class CommandeDvd{



		public int Id { get; set; }
		public DateTime DateCommande { get; set; }
		public decimal Montant { get; set; }
		public int NombreExemplaires { get; set; }
		public string EtapeSuivi { get; set; }
		public string Isbn { get; set; }

		p public CommandeDvd(string id, string titre, string image, int duree, string realisateur, string synopsis,
			string idGenre, string genre, string idPublic, string lePublic, string idRayon, string rayon, string isbn, int id, DateTime dateCommande, decimal montant, int nombreExemplaires, string collection, string etapeSuivi, string isbn,)
			: base(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon)
		{
			this.Duree = duree;
			this.Realisateur = realisateur;
			this.Synopsis = synopsis;
		}
			this.Id = id;
			this.DateCommande = dateCommande;
			this.Montant = montant;
			this.NombreExemplaires = nombreExemplaires;
			this.EtapeSuivi = etapeSuivi;
			this.Isbn = isbn;
			

		}

	}
}