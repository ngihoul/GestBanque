using Models;

Personne p1 = new Personne()
{
    Nom = "Bichette",
    Prenom = "Bo",
    DateNaiss = new DateTime(1991, 06, 05)
};

Courant c1 = new Courant()
{
    Numero = "BE00 0001 0002 0003",
    Titulaire = p1
};

c1.Depot(2000);

Courant c2 = new Courant()
{
    Numero = "BE00 0004 0005 0006",
    Titulaire = p1,
};

c2.Depot(5000);

Courant c3 = new Courant()
{
    Numero = "BE01 0002 0003 0004",
    LigneDeCredit = 1500,
    Titulaire = p1,
};

c3.Retrait(1000);

Banque b = new Banque();
b.Ajouter(c1);
b.Ajouter(c2);
b.Ajouter(c3);

Console.WriteLine(b["BE01 0002 0003 0004"].Titulaire.Nom);

// Test surcharge +
double soldeC1C2 = c1 + c2;
Console.WriteLine($"Solde C1 + C2 = {soldeC1C2}");

double soldeC2C3 = c2 + c3;
Console.WriteLine($"Solde C2 + C3 = {soldeC2C3}");

// Test Avoir des comptes
double avoirsP1 = b.AvoirDesComptes(p1);
Console.WriteLine($"Avoirs de {p1.Nom} : {avoirsP1}");