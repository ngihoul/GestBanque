using Models;

Courant c1 = new Courant()
{
    Numero = "BE00 0001 0002 0003",
};

c1.Depot(2000);

Courant c2 = new Courant()
{
    Numero = "BE00 0004 0005 0006",
};

c2.Depot(5000);

Banque b = new Banque();
b.Ajouter(c1);
b.Ajouter(c2);

Console.WriteLine(b["BE00 0001 0002 0003"].Solde);

