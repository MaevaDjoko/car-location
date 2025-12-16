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
	}
}