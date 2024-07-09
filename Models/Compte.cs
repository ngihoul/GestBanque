using Models.Exceptions;
using Models.Interface;

namespace Models
{
    public delegate void PassageEnNegatifDelegate(Compte compte);
    public abstract class Compte : IBanker, ICustomer
    {
        #region Evènements
        public event PassageEnNegatifDelegate? PassageEnNégatifEvent = null;

        protected void PassageSoldeNegatif()
        {
            PassageEnNégatifEvent?.Invoke(this);
        }
        #endregion

        #region Props
        public string Numero { get; private set; }
        public virtual double Solde { get; private set; }
        public Personne Titulaire { get; private set; }
        protected virtual double SoldeDisponible
        {
            get
            {
                return Solde;
            }
        }
        #endregion

        #region Constructeurs
        public Compte() { }
        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
            Solde = 0;
        }

        public Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            Solde = solde;
        }
        #endregion

        #region Méthodes
        public virtual void Retrait(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Retrait négatif ou nul impossible");
            }

            if (montant > SoldeDisponible)
            {
                throw new SoldeInsuffisantException(this, montant);
            }

            Solde -= montant;
        }

        public virtual void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant),"Dépot négatif ou nul impossible");
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
