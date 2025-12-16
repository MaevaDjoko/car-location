using System;

namespace LocationVoitures
{
    // Interface Paiement
    interface IPaiement
    {
        void Pay(float montant);
    }

    // Paiement par carte bancaire
    class CreditCard : IPaiement
    {
        private string NumeroCarte;

        public CreditCard(string numeroCarte)
        {
            NumeroCarte = numeroCarte;
        }

        public void Pay(float montant)
        {
            Console.WriteLine($"Paiement de {montant} effectué par carte : {NumeroCarte}");
        }
    }

    // Paiement par Paypal
    class Paypal : IPaiement
    {
        private string Email;

        public Paypal(string email)
        {
            Email = email;
        }

        public void Pay(float montant)
        {
            Console.WriteLine($"Paiement de {montant} effectué par Paypal : {Email}");
        }
    }

    // État d’une voiture
    enum Etat
    {
        Disponible,
        Loue,
        EnMaintenance
    }

    // Classe Client (classe mère)
    class Client
    {
        protected string Nom;
        protected string Prenom;
        protected string Email;
        protected int Id;

        public Client(string prenom, string nom, string email, int id)
        {
            Prenom = prenom;
            Nom = nom;
            Email = email;
            Id = id;
        }

        public virtual void Display()
        {
            Console.WriteLine($"{Prenom}, {Nom}, {Email}, {Id}");
        }
    }

    // Client particulier
    class ClientParticulier : Client
    {
        public ClientParticulier(string prenom, string nom, string email, int id)
            : base(prenom, nom, email, id)
        {
        }
    }

    // Client premium
    class ClientPremium : Client
    {
        public float Remise { get; private set; }

        public ClientPremium(string prenom, string nom, string email, int id, float remise)
            : base(prenom, nom, email, id)
        {
            Remise = remise;
        }

        public override void Display()
        {
            Console.WriteLine($"{Prenom}, {Nom}, {Email}, {Id} (Premium - remise {Remise * 100}%)");
        }
    }

    // Classe Voiture
    class Voiture
    {
        public int Immatriculation { get; private set; }
        public string Nom { get; private set; }
        public string Modele { get; private set; }
        public Etat Etat { get; private set; }

        public Voiture(int immatriculation, string nom, string modele, Etat etat)
        {
            Immatriculation = immatriculation;
            Nom = nom;
            Modele = modele;
            Etat = etat;
        }
    }

    // Options disponibles
    enum Option
    {
        GPS,
        SiegeEnfant,
        AssuranceSupplementaire
    }

    // Classe Location
    class Location
    {
        private Client Client;
        private Voiture Voiture;
        private double Prix;
        private int Duree;
        private IPaiement TypePaiement;

        public Location(Client client, Voiture voiture, double prix, int duree, IPaiement typePaiement)
        {
            Client = client;
            Voiture = voiture;
            Prix = prix;
            Duree = duree;
            TypePaiement = typePaiement;
        }

        public void Checkout()
        {
            Console.WriteLine($"Location pour {Duree} jours");
            TypePaiement.Pay((float)Prix);
        }
    }

    // Programme principal
    class Programme
    {
        static void Main()
        {
            Client client1 = new ClientPremium(
                "Matthieu",
                "Mohimbouabeka",
                "mohimbouabeka@gmail.com",
                1,
                0.15f
            );

            client1.Display();

            Voiture voiture = new Voiture(12345, "Toyota", "Corolla", Etat.Disponible);

            IPaiement paiement = new CreditCard("1234-5678-9012-3456");

            Location location = new Location(client1, voiture, 250.0, 3, paiement);

            location.Checkout();
        }
    }
}
