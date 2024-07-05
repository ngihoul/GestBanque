using Models.Interface;

namespace Models
{
    public abstract class Compte : IBanker, ICustomer
    {
        #region Props
        public string Numero { get; set; }
        public double Solde { get; private set; }
        public Personne Titulaire { get; set; }
        protected virtual double SoldeDisponible
        {
            get
            {
                return Solde;
            }
        }
        #endregion

        #region Méthodes
        public virtual void Retrait(double montant)
        {
            if (montant <= 0)
            {
                throw new Exception("Retrait négatif ou nul impossible");
            }

            if (montant > SoldeDisponible)
            {
                throw new Exception();
            }

            Solde -= montant;
        }

        public virtual void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new Exception("Dépot négatif ou nul impossible");
            }

            Solde += montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }
        #endregion

        #region Surcharge opérateurs
        public static double operator +(Compte a, Compte b)
        {
            if (a.Solde < 0)
            {
                return b.Solde;
            }
            else if (b.Solde < 0)
            {
                return a.Solde;
            }

            return a.Solde + b.Solde;
        }
        #endregion
    }
}
