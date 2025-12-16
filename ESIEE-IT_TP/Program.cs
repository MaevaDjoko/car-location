
interface Paiement
{
    void pay(float montant);
}

class Creditcard : Paiement
{
    string numerocarte;
    public Creditcard(string NumeroCarte)
    {
        numerocarte = NumeroCarte;
    }
    public void pay(float montant)
    {
        Console.WriteLine($"Paiement de {montant} effectué par carte, {numerocarte}");
    }
}

class Paypal : Paiement
{
    string email;
    public Paypal(string Email)
    {
        email = Email;
    }

    public void pay(float montant)
    {
        Console.WriteLine($"Paiement de {montant} effectué par paypal {email}");
    }
}

class PaiementLivraison : Paiement
{
    public void pay(float montant)
    {
        Console.WriteLine($"Paiement de {montant} à la livraison");
    }
}
class Commande
{
    Paiement typepaiement;
    float montant;

    public Commande(Paiement TypePaiment, float Montant)
    {
        typepaiement = TypePaiment;
        montant = Montant;
    }

    public void checkout()
    {
        typepaiement.pay(montant);
    }
}

class Programme
{
    static void Main()
    {
        Commande CI = new Commande(new Creditcard("12456"), 200.0f);
        CI.checkout();
    }
}
