namespace ESIEE_IT_TP.models
{    
    // pour pouvoir faire la modification de façon dynamique sans casser tout le code
    public enum Etat
    {
        Disponible,
        Loué,
        EnMaintenance
    }

    public class Voiture
    {
        public int Immatriculation { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
        public Etat Etat { get; set; }

        public Voiture(int immatriculation, string marque, string modele, int annee, Etat etat)
        {
            Immatriculation = immatriculation;
            Marque = marque;
            Modele = modele;
            Annee = annee;
            Etat = etat;
        }
    }
}
