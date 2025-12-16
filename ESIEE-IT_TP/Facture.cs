using System;

public class Facture
{
	private int id {  get; set; }
	private Paiement Paiement { get; set; };
	private Location Location { get; set; };

	public Facture(int id, Paiement paiement, Location location)
	{
		id = id;
		Paiement = paiement;
		Location = location;
	}
}
