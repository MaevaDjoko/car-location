namespace ESIEE_IT_TP.models
{
    public abstract class ClientBase
    {
        protected string? Email { get; set; }
        protected string? Nom { get; set; }
        protected string? Prenom { get; set; }
        protected List<Location>? Locations { get; set; } 

        public void display()
        {
            Console.WriteLine($"un client {Nom}");
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