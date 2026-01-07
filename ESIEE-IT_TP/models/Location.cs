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
        public bool EstActive { get; private set; } = true;
        public Promotion? Promotion { get; set; }
        public float DepotGarantie { get; private set; }
        public bool DepotVerse { get; private set; } = false;

        // Calcul dynamique du prix total
        public float PrixTotal
        {
            get
            {
                float optionsTotal = Options.Sum(o => o.CalculerPrix(Duree));
                float total = (PrixParJour * Duree) + optionsTotal;

                if (Duree >= 7)
                    total *= 0.85f;

                if (Promotion != null)
                    total = Promotion.appliquer(total);

                if (Client is ClientPremium premium)
                {
                    total *= (1 - premium.Remise);
                }

                return total;
            }
        }

        public Location(ClientBase client, Voiture voiture, float prixparjour, int duree, Paiement typepaiement, List<Options>? options = null)
		{
            if (voiture.Etat != Etat.Disponible)
                throw new Exception("Véhicule non disponible");

            if (duree > 30)
                throw new Exception("La location ne peut pas dépasser 30 jours");

            if (!client.peutLouer())
                throw new Exception("Le client a déjà 3 locations actives");

            if (voiture.besoinMaintenance())
                throw new Exception("Le véhicule doit passer en maintenance avant d'être loué");

            Client = client;
			Voiture = voiture;
			PrixParJour = prixparjour;
			Duree = duree;
			Typepaiement = typepaiement;
            Options = options ?? new List<Options>();
            EstActive = true;

            Voiture.Etat = Etat.Loué;

            Client.ajouterLocation(this);

        }

        public void checkout()
		{
			Typepaiement.pay(PrixTotal);
            int idFacture = Client.Factures.Count + 1;
            Facture facture = new Facture(idFacture, this);

            Client.Factures.Add(facture);
        }

        public void verserDepot(float montant)
        {
            if (montant < calculDepotRequis())
                throw new Exception($"Le dépôt minimum requis est {calculDepotRequis()} €");

            DepotGarantie = montant;
            DepotVerse = true;
            Console.WriteLine($"Dépôt de {DepotGarantie} euros versé.");
        }

        // Montant minimum requis pour le dépôt (20% du prix total)
        private float calculDepotRequis()
        {
            return PrixTotal * 0.2f;
        }

        private void inspecterVoiture()
        {
            Console.WriteLine($"Inspection du véhicule {Voiture.Modele} effectuée.");

            // Après inspection, si tout est ok, le dépôt peut être restitué
            DepotVerse = false;
            DepotGarantie = 0;
            Console.WriteLine("Dépôt de garantie restitué au client.");
        }

        public void cloturer()
        {
            if (!DepotVerse)
                throw new Exception("Le dépôt de garantie doit être versé avant la clôture de la location.");

            EstActive = false;

            // Vérifier maintenance
            if (Voiture.besoinMaintenance())
                Voiture.Etat = Etat.EnMaintenance;
            else
                Voiture.Etat = Etat.Disponible;

            // Inspection et restitution du dépôt
            inspecterVoiture();

            Console.WriteLine($"Location terminée. Véhicule {Voiture.Modele} est maintenant {Voiture.Etat}");
        }


    }
}