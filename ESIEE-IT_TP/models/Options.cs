namespace ESIEE_IT_TP.models
{
    public enum TypeTarification
    {
        PrixFixe,
        PrixParJour
    }
    public class Options
    {
        public string Nom { get; }
        public float Prix { get; } // prix fixe ou par jour
        public TypeTarification Tarification { get; }

        public Options(string nom, float prix, TypeTarification tarification)
        {
            Nom = nom;
            Prix = prix;
            Tarification = tarification;
        }

        // Calcul du montant selon la durée
        public float CalculerPrix(int duree)
        {
            return Tarification switch
            {
                TypeTarification.PrixFixe => Prix,
                TypeTarification.PrixParJour => Prix * duree,
                _ => 0
            };
        }

    }
}
