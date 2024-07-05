namespace Models
{
    public class Banque
    {
        private Dictionary<string, Compte> _Comptes = new Dictionary<string, Compte>();

        public string Nom { get; set; }

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
        ///    Ajouter un compte courant au dictionnaire
        /// </summary>
        public void Ajouter(Courant compte) {
            if (this[compte.Numero] != null)
            {
                Console.WriteLine($"Le compte numéro : {compte.Numero} existe déjà!!!");
                return;
            }

            _Comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero) {
            if (!_Comptes.ContainsKey(numero))
            {
                Console.WriteLine($"Le compte numéro : {numero} n'existe pas!!!");
                return;
            }

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
    }
}
