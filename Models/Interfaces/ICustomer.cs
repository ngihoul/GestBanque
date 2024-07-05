namespace Models.Interface
{
    public interface ICustomer
    {
        #region Props
        double Solde { get; }
        #endregion

        #region Méthodes
        void Depot(double amount);
        void Retrait(double montant);
        #endregion
    }
}
