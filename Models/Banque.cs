namespace Models
{
    public class Banque
    {
        private Dictionary<string, Courant> _Comptes = new Dictionary<string, Courant>();

        public string Nom { get; set; }

        public Courant this[string numero] { 
            get {
                _Comptes.TryGetValue(numero, out Courant c);
                return c;
            }
        }
        /// <summary>
        ///    Ajouter un compte courant au dictionnaire
        /// </summary>
        public void Ajouter(Courant compte) {
            _Comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero) {
            _Comptes.Remove(numero);
        }
    }
}
