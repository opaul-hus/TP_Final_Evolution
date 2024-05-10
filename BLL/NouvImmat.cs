using DAL;
using System.ComponentModel;

namespace BLL
{
    public class NouvImmat : INotifyPropertyChanged
    {
        private int _annee;
        public int Annee { get; set; }

        private string _codePr;
        public string CodePr
        {
            get
            {
                return _codePr;
            }

            set
            {
                if (this._codePr != value)
                {
                    this._codePr = value;
                    this.NotifyPropertyChanged("CodePr");
                }
            }
        }

        private string _codeCarb;
        public string CodeCarb
        {
            get
            {
                return _codeCarb;
            }

            set
            {
                if (this._codeCarb != value)
                {
                    this._codeCarb = value;
                    this.NotifyPropertyChanged("CodeCarb");
                }
            }
        }

        private string _codeGen;
        public string CodeGen
        {
            get
            {
                return _codeGen;
            }

            set
            {
                if (this._codeGen != value)
                {
                    this._codeGen = value;
                    this.NotifyPropertyChanged("CodeGen");
                }
            }
        }

        private double _nbreImmats;
        public double NbreImmats
        {
            get
            {
                return _nbreImmats;
            }

            set
            {
                if (this._nbreImmats != value)
                {
                    this._nbreImmats = value;
                    this.NotifyPropertyChanged("NbreImmats");
                }
            }
        }


        private CodePr _province;
        public CodePr Province
        {
            get
            {
                return _province;
            }

            set
            {
                if (this._province != value)
                {
                    this._province = value;
                    this.NotifyPropertyChanged("Province");
                }
            }
        }

        private CodeGen _typeVehicule;
        public CodeGen TypeVehicule
        {
            get
            {
                return _typeVehicule;
            }

            set
            {
                if (this._typeVehicule != value)
                {
                    this._typeVehicule = value;
                    this.NotifyPropertyChanged("TypeVehicule");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


        public double Pourcentage { get { return calculPourcentage(); } }
        private double calculPourcentage()
        {
            return AccessDB.GetSepcificVehiculeCount(_codePr, _annee, _codeCarb) / AccessDB.GetVehiculeCount(_codePr, _annee);
        }


    }

  public enum CodeCarb
    {
        VHR,
        VHE,
        VEB,
        Ess,
        Di,
        Autres
    }

    public enum CodeGen
    {
        CAM,
        FOU,
        VP,
        VUM
    }

    public enum CodePr
    {
        QC,
        ON,
        BCP,
        AB,
        MB,
        SK,
        NS,
        NB,
        PE,
        NL

    }





}
