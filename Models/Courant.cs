using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Courant
    {
        public string Numero { get; set; }
        public double Solde { get; private set; }
        public double LigneDeCredit
        {
            set
            {
                if (value >= 0)
                {
                    LigneDeCredit = value;
                }
                else
                {
                    throw new Exception();
                }

            }
        }
        public Personne Titulaire { get; set; }

        public void Retrait(double Montant)
        {
            Solde = Montant > 0 ? Solde -= Montant : throw new Exception();
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
