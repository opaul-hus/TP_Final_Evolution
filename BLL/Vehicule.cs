namespace BLL
{
    public class Vehicule
    {

        private string nom;

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                if (this.nom != value)
                {
                    this.nom = value;

                }

            }
        }
    }
}