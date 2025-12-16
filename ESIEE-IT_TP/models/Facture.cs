namespace ESIEE_IT_TP.models
{
	public class Facture
	{
		public int id { get; set; }
		public Paiement Paiement { get; set; }
		public Location Location { get; set; }

		public Facture(int Id, Paiement paiement, Location location)
		{
			id = Id;
			Paiement = paiement;
			Location = location;
		}
	}
}
