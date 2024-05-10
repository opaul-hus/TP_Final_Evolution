namespace BLL
{
    public class Province
    {
        public Province()
        {


        }

        private string code;

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                if (this.code != value)
                {
                    this.code = value;

                }
            }
        }   

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