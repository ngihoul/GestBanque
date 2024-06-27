namespace Models
{
    public class Courant
    {
        public string Numero { get; set; }
        public double Solde { get; private set; }

        private double _LigneDeCredit;
        public double LigneDeCredit
        {
            set
            {
                if (value >= 0)
                {
                    _LigneDeCredit = value;
                }
                else
                {
                    throw new Exception();
                }
            }

            get { return _LigneDeCredit; }
        }
        public Personne Titulaire { get; set; }

        public void Retrait(double Montant)
        {
            if (Montant > 0 && Montant <= Solde + LigneDeCredit)
            {
                Solde -= Montant;
            }
            else
            {
                throw new Exception();
            }
        }

        public void Depot(double Montant)
        {
            if (Montant > 0)
            {
                Solde += Montant;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
