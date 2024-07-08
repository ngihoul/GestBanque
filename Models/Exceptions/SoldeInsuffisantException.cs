using System.ComponentModel;

namespace Models.Exceptions
{
    public class SoldeInsuffisantException : Exception
    {
        #region Props
        public string Numero { get; private set; }
        public double Solde { get; private set; }
        public double Montant { get; private set; }
        #endregion

        #region Méthodes
        public SoldeInsuffisantException(Compte compte, double montant, string message) : base(message)
        {
            Numero = compte.Numero;
            Solde = compte.Solde;
            Montant = montant;
        }

        public SoldeInsuffisantException(Compte compte, double montant) : this(compte, montant, "Le solde est insuffisant") { }
        #endregion
    }
}
