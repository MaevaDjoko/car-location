using System;

public class ClientBase
{
    private string Email { get; set; };
    private string Nom { get; set; };
    private string Prenom { get; set; };
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
    private float Remise { get; set; };
    public ClientPremium(string email, string nom, string prenom, float remise)
    {
        Nom = nom;
        Prenom = prenom;
        Email = email;
        Remise = remise;
    }

}