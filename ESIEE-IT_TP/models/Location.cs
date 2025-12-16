using System;

namespace Models
{
	public class Location
	{
		public ClientBase Client { get; set; }
		public Voiture Voiture { get; set; }
		public float Prix { get; set; }
		public int Duree { get; set; }
		public Paiement Typepaiement { get; set; }

		public Location(ClientBase client, Voiture voiture, float prix, int duree, Paiement typepaiement)
		{
			Client = client;
			Voiture = voiture;
			Prix = prix;
			Duree = duree;
			Typepaiement = typepaiement;
		}

		public void checkout()
		{
			Typepaiement.pay(Prix);
		}
	}
}