namespace ESIEE_IT_TP.models
{
    public abstract class ClientBase
    {
        protected string? Email { get; set; }
        protected string? Nom { get; set; }
        protected string? Prenom { get; set; }
        protected List<Location>? Locations { get; set; } 
        public List<Facture> Factures { get; } = new();

        public void display()
        {
            Console.WriteLine($"un client {Nom}");
        }

        public void ajouterLocation(Location location)
        {
            Locations ??= new List<Location>();
            Locations.Add(location);
        }

        public bool peutLouer()
        {
            return Locations == null || Locations.Count(l => l.EstActive) <= 3;
        }

        public void afficherFactures()
        {
            foreach (var f in Factures)
                Console.WriteLine($"Facture #{f.id} pour {f.Location.Voiture.Modele} de M./Mme {Nom} - {Prenom}: {f.Location.PrixTotal} euros");
        }
    }

    public class ClientParticulier : ClientBase
    {
        public ClientParticulier(string email, string nom, string prenom, List<Location> locations = null)
	    {
            Email = email;
            Nom = nom;
            Prenom = prenom;
            Locations = locations;
	    }

    }

    // un client premium dépasse la durée de 30 jours de location quand il est premium
    public class ClientPremium : ClientBase
    {
        public float Remise { get; set; }
        public ClientPremium(string email, string nom, string prenom, float remise, List<Location> locations)
        {
            Email = email;
            Nom = nom;
            Prenom = prenom;
            Locations = locations;
            Remise = remise;
        }

    }
}