using Models;

Courant c1 = new Courant()
{
    Numero = "BE00 0001 0002 0003",
    Titulaire = new Personne()
    {
        Nom = "Albert",
        Prenom = "Jean-Charles",
        DateNaiss = new DateTime(1988, 12, 23)
    }
};

c1.Depot(2000);

Courant c2 = new Courant()
{
    Numero = "BE00 0004 0005 0006",
    Titulaire = new Personne()
    {
        Nom = "Bichette",
        Prenom = "Bo",
        DateNaiss = new DateTime(1991, 06, 05)
    }
};

c2.Depot(5000);

Courant c3 = new Courant()
{
    Numero = "BE01 0002 0003 0004",
    Titulaire = new Personne()
    {
        Nom = "Guerrero",
        Prenom = "Vladimir Jr.",
        DateNaiss = new DateTime(1995, 05, 04)
    }
};

Banque b = new Banque();
b.Ajouter(c1);
b.Ajouter(c2);
b.Ajouter(c3);

Console.WriteLine(b["BE01 0002 0003 0004"].Titulaire.Nom);

