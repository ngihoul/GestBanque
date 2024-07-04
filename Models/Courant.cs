namespace Models
{
    public class Courant : Compte
    {
        #region Champs
        private const double TX_DEBITEUR = 9.75;
        private const double TX_CREDITEUR = 3;

        private double _LigneDeCredit;
        #endregion

        #region Props
        public double LigneDeCredit
        {
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ligne de crédit négative");
                }

                _LigneDeCredit = value;
            }

            get { return _LigneDeCredit; }
        }
        protected override double SoldeDisponible { get { return Solde + LigneDeCredit; } }
        #endregion

        #region Méthodes
        protected override double CalculInteret()
        {
            double taux = Solde  >= 0 ? TX_CREDITEUR : TX_DEBITEUR;
            return Solde * (taux / 100);
        }
        #endregion
    }
}
