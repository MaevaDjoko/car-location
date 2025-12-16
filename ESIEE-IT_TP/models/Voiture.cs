using System;

namespace Models
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
        public string Nom { get; set; }
        public string Modele { get; set; }
        public Etat Etat { get; set; }

        public Voiture(int immatriculation, string nom, string modele, Etat etat)
        {
            Immatriculation = immatriculation;
            Nom = nom;
            Modele = modele;
            Etat = etat;
        }
    }
}
