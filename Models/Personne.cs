namespace Models
{
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaiss { get; set; }

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
