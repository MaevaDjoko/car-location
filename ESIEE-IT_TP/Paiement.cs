using System;

interface Paiement
{
    void pay(float montant);
}

class Creditcard : Paiement
{
    string Numerocarte;
    public Creditcard(string numeroCarte)
    {
        Numerocarte = mumeroCarte;
    }
    public void pay(float montant)
    {
        Console.WriteLine($"Paiement de {montant} effectué par carte, {numerocarte}");
    }
}

class Paypal : Paiement
{
    string Email;
    public Paypal(string email)
    {
        Email = email;
    }

    public void pay(float montant)
    {
        Console.WriteLine($"Paiement de {montant} effectué par paypal {email}");
    }
}
