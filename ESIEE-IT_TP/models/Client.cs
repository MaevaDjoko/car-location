using System;

namespace Models
{
    public abstract class ClientBase
    {
        protected string? Email { get; set; }
        protected string? Nom { get; set; }
        protected string? Prenom { get; set; }

        public void display()
        {
            Console.WriteLine($"un client {Nom}");
        }
    }

    public class ClientParticulier : ClientBase
    {
        public ClientParticulier(string email, string nom, string prenom)
	    {
            Email = email;
            Nom = nom;
            Prenom = prenom;
	    }

    }

    // un client premium dépasse la durée de 30 jours de location quand il est premium
    public class ClientPremium : ClientBase
    {
        public float Remise { get; set; }
        public ClientPremium(string email, string nom, string prenom, float remise)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Remise = remise;
        }

    }
}