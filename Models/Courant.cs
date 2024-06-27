namespace Models
{
    public class Courant
    {
        #region Props
        public string Numero { get; set; }
        public double Solde { get; private set; }

        private double _LigneDeCredit;
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
        public Personne Titulaire { get; set; }

        private double SoldeDisponible { get { return Solde + LigneDeCredit; } }
        #endregion

        #region Methods
        public void Retrait(double montant)
        {
            if (montant <= 0)
            {
                throw new Exception("Retrait négatif ou nul impossible");
            }

            if (montant > SoldeDisponible)
            {
                throw new Exception("Solde insuffisant");
            }

            Solde -= montant;
        }

        public void Depot(double montant)
        {
            if (montant >= 0)
            {
                throw new Exception("Dépot négatif ou nul impossible");
            }

            Solde += montant;
        }
        #endregion
    }
}
