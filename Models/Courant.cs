namespace Models
{
    public class Courant : Compte
    {
        #region Constantes
        private const double TX_DEBITEUR = 9.75;
        private const double TX_CREDITEUR = 3;
        #endregion

        #region Champs
        private double _LigneDeCredit;
        #endregion

        #region Props
        public double LigneDeCredit
        {
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Ligne de crédit négative");
                }

                _LigneDeCredit = value;
            }

            get { return _LigneDeCredit; }
        }
        protected override double SoldeDisponible { get { return Solde + LigneDeCredit; } }
        #endregion

        #region Constructeurs
        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {
            LigneDeCredit = 0;
        }
        public Courant(string numero, Personne titulaire, double solde, double ligneDeCredit) : base(numero, titulaire, solde)
        {
            LigneDeCredit = ligneDeCredit;
        }
        public Courant(string numero, Personne titulaire, double ligneDeCredit) : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public override void Retrait(double montant)
        {
            bool soldeInitialPositif = Solde >= 0;

            base.Retrait(montant);

            if (soldeInitialPositif && Solde < 0)
            {
                PassageSoldeNegatif();
            }
        }
        #endregion

        #region Méthodes
        protected override double CalculInteret()
        {
            double taux = Solde >= 0 ? TX_CREDITEUR : TX_DEBITEUR;
            return Solde * (taux / 100);
        }
        #endregion
    }
}
