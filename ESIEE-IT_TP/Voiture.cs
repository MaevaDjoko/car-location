using System;

// pour pouvoir faire la modification de façon dynamique sans casser tout le code
enum Etat
{
    Disponible,
    Loué,
    En maintenance
}

public class Voiture
{
	private int Immatriculation { get; set; };
	private string Nom { get; set; };
	private string Modele { get; set; };
	private Etat Etat

    public Voiture(int immatriculation, string nom, string modele, Etat etat)
	{
        Immatriculation = immatriculation;
        Nom = nom;
        Modele = modele;
        Etat = etat;
    }
}
