namespace Models
{
    public class Personne
    {
        #region Champs
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public DateTime DateNaiss { get; private set; }
        #endregion

        #region Constructeurs
        public Personne(string nom, string prenom, DateTime dateNaiss)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaiss = dateNaiss;
        }
        #endregion

        public static bool operator ==(Personne? left, Personne? right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Nom == right.Nom && left.Prenom == right.Prenom && left.DateNaiss == right.DateNaiss;
        }

        public static bool operator !=(Personne? left, Personne? right)
        {
            return !(left == right);
        }
    }
}
