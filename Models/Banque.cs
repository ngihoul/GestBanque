using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banque
    {
        private Dictionary<string, Courant> _Comptes = new Dictionary<string, Courant>();

        public string Nom { get; set; }

        public Courant this[string key] { 
            get {
                _Comptes.TryGetValue(key, out Courant c);
                return c;
            }
            set {
                _Comptes[key] = value;
            }
        }

        public void Ajouter(Courant compte) {
            _Comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero) {
            _Comptes.Remove(numero);
        }
    }
}
