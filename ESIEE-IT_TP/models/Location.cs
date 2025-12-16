namespace ESIEE_IT_TP.models
{
	public class Location
	{
		public ClientBase Client { get; set; }
		public Voiture Voiture { get; set; }
		public float PrixParJour { get; set; }
		public int Duree { get; set; }
		public Paiement Typepaiement { get; set; }
        public List<Options> Options { get; }

        // Calcul dynamique du prix total
        public float PrixTotal
        {
            get
            {
				float optionsTotal = Options.Sum(o => o.CalculerPrix(Duree));
				if (Duree >= 7)
					return ((PrixParJour * Duree) + optionsTotal) * 0.15f;
				else 
					return (PrixParJour * Duree) + optionsTotal;
            }
        }

        public Location(ClientBase client, Voiture voiture, float prixparjour, int duree, Paiement typepaiement, List<Options> options = null)
		{
			Client = client;
			Voiture = voiture;
			PrixParJour = prixparjour;
			Duree = duree;
			Typepaiement = typepaiement;
            Options = options;
        }

		public void checkout()
		{
			Typepaiement.pay(PrixTotal);
		}

		public void isValid()
		{
			if (Duree > 30)
			{
				Console.WriteLine("La location ne doit pas excéder 30 jours");
			}
		}
	}
}