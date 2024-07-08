using Models;
using Models.Interface;
using Models.Exceptions;

Personne p1 = new Personne("Bichette", "Bo", new DateTime(1991, 06, 05));

Courant c1 = new Courant("BE00 0001 0002 0003", p1);

c1.Depot(2000);

Courant c2 = new Courant("BE00 0004 0005 0006", p1);

c2.Depot(5000);

Courant c3 = new Courant("BE00 0002 0003 0004", p1, 1500);

c3.Retrait(1000);

Banque b = new Banque();
b.Ajouter(c1);
b.Ajouter(c2);
b.Ajouter(c3);

Console.WriteLine(b["BE00 0002 0003 0004"]!.Titulaire.Nom);

// Test surcharge +
double soldeC1C2 = c1 + c2;
Console.WriteLine($"Solde C1 + C2 = {soldeC1C2}");

double soldeC2C3 = c2 + c3;
Console.WriteLine($"Solde C2 + C3 = {soldeC2C3}");

// Test Avoir des comptes
double avoirsP1 = b.AvoirDesComptes(p1);
Console.WriteLine($"Avoirs de {p1.Nom} : {avoirsP1}");

ICustomer customer = c1;
customer.Depot(2000);
customer.Retrait(1500);
// On ne peut pas accéder au titulaire via l'interface ICustomer
IBanker banker = c2;

if (customer is Courant c)
{
    Courant c4 = new Courant("42", p1, c.Solde, c.LigneDeCredit);

    c.Retrait(c.Solde);

    b.Ajouter(c4);
}

try
{
     // customer.Depot(-5000);
     customer.Retrait(-2000);
    customer.Depot(2_000_000_000);
    Console.WriteLine(customer.Solde);
}
catch (ArgumentOutOfRangeException outOfRange)
{
    Console.WriteLine($"Erreur : {outOfRange.Message}");
}
catch (SoldeInsuffisantException soldeInsuffisant)
{
    Console.WriteLine($"Erreur : {soldeInsuffisant.Message}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Courant c4 = new Courant("BE02 0009 0008 0007", p1, -5000);
}
catch (InvalidOperationException invalidOperation)
{
    Console.WriteLine($"Erreur : {invalidOperation.GetType()}");
}
catch (Exception e)
{
    Console.WriteLine($"Erreur : {e.Message}");
}

