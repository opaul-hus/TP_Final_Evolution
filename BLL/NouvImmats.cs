using DAL;
using System.Collections.ObjectModel;
using System.Data;



namespace BLL
{
    public class NouvImmats
    {
        public static ObservableCollection<NouvImmat> nouvImats = new ObservableCollection<NouvImmat>();
        public static void ChargerListeNouvImmats()
        {
            DataTable dt = AccessDB.ConnecterBD();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                nouvImats.Add(new NouvImmat
                {

                    Annee = (int)dt.Rows[i]["Annee"],
                    CodePr = dt.Rows[i]["CodePr"].ToString(),
                    CodeCarb = dt.Rows[i]["CodeCarb"].ToString(),
                    CodeGen = dt.Rows[i]["CodeGen"].ToString(),
                    NbreImmats = (double)dt.Rows[i]["NbreImmats"],
                    Province =  (CodePr)Enum.Parse(typeof(CodePr), dt.Rows[i]["CodePr"].ToString()),
                    TypeVehicule = (CodeGen)Enum.Parse(typeof(CodeGen), dt.Rows[i]["CodeGen"].ToString()),
                    
                });
            }
        }

  
    }
}
