using System;

public class Location
{
	private Client Client { get; set; };
	private Voiture Voiture { get; set; };
	private double Prix { get; set; };
	private int Duree { get; set; };
	private Paiement Typepaiement { get; set; };

    public Location(Client client, Voiture voiture, double prix, int duree, Paiement typepaiement)
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
