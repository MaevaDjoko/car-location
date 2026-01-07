using ESIEE_IT_TP.models;

class Maine
{
    static void Main()
    {
        /*ClientParticulier client = new ClientParticulier("maevadjoko@gmail.com", "Maeva", "Djoko");
        client.display();*/

        // Création du client
        var client = new ClientParticulier("test@email.com", "Dupont", "Jean");

        // Création d'une voiture
        var voiture = new Voiture(1234, "Peugeot", "208", 2020, 5000, Etat.Disponible, DateTime.Now.AddMonths(-4));

        var options = new List<Options>
        {
            new Options("GPS", 5, TypeTarification.PrixParJour),
            new Options("Siège enfant", 20, TypeTarification.PrixFixe)
        };

        var paiement = new Creditcard("1234-5678-9012-3456");

        var location = new Location(client, voiture, 50, 10, paiement, options);

        location.verserDepot(100);

        // Paiement
        location.checkout();

        // Clôture de la location et inspection
        location.cloturer();

        // Affichage de l'historique des factures
        client.afficherFactures();
    }
}
