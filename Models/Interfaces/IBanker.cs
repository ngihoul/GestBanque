namespace Models.Interface
{
    public interface IBanker : ICustomer
    {
        #region Props
        Personne Titulaire { get; }
        string Numero { get; }
        #endregion

        #region Méthodes
        void AppliquerInteret();
        #endregion

       // Si ajout props LigneDeCredit à IBanker : 
       //     - Ajout LigneDeCredit en abstract à class Compte
       //     - Ovveride LigneDeCredit dans Courant et Epargne (la mettre à zéro)
    }
}
