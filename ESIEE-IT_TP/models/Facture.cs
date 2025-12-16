namespace ESIEE_IT_TP.models
{
	public class Facture
	{
		public int id { get; set; }
		public Location Location { get; set; }

		public Facture(int Id, Location location)
		{
			id = Id;
			Location = location;
		}
	}
}
