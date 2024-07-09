namespace Models
{
    public class Banque
    {
        #region Event
        public event Action<string>? BanqueNotifEvent = null;

        protected void DeclenchementBanqueNotifEvent(string message)
        {
            BanqueNotifEvent?.Invoke(message);
        }
        #endregion

        #region Champs
        private Dictionary<string, Compte> _Comptes = new Dictionary<string, Compte>();
        #endregion

        #region Props
        public string Nom { get; set; }
        #endregion

        #region Méthodes
        public Compte? this[string numero] { 
            get {
                foreach (KeyValuePair<string, Compte> kvp in _Comptes)
                {
                    if (kvp.Key == numero)
                    {
                        return kvp.Value;
                    }
                }
                return null;
            }
        }
        /// <summary>
        ///    Ajouter un compte au dictionnaire
        /// </summary>
        public void Ajouter(Courant compte) {
            if (this[compte.Numero] != null)
            {
                DeclenchementBanqueNotifEvent($"Le compte numéro : {compte.Numero} existe déjà!!!");
                return;
            }

            _Comptes.Add(compte.Numero, compte);

            // Abonnement à l'event
            compte.PassageEnNégatifEvent += DetectionPassageEnNegatif;
        }

        private void DetectionPassageEnNegatif(Compte compte)
        {
            DeclenchementBanqueNotifEvent($"Warning : le solde du compte {compte.Numero} est en négatif");
        }

        public void Supprimer(string numero) {
            if (!_Comptes.ContainsKey(numero))
            {
                DeclenchementBanqueNotifEvent($"Le compte numéro : {numero} n'existe pas!!!");
                return;
            }

            // Désabonnement à l'event
            _Comptes[numero].PassageEnNégatifEvent -= DetectionPassageEnNegatif;

            _Comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            Compte temp = new Courant("temp", titulaire);
            double result = 0;

            foreach (KeyValuePair<string, Compte> kvp in _Comptes)
            {
                Compte compte = kvp.Value;

                if (compte.Titulaire == titulaire)
                {
                    double montant = temp + compte;

                    result += montant;
                }
            }

            return result;
        }
        #endregion
    }
}
