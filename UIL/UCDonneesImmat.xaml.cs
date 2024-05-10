using BLL;
using System.ComponentModel;
using System.DirectoryServices;
using System.Windows.Controls;


namespace UIL
{
    /// <summary>
    /// Interaction logic for UCDonneesImmat.xaml
    /// </summary>
    public partial class UCDonneesImmat : UserControl
    {
        private ListSortDirection sortDirection = ListSortDirection.Ascending;

        public UCDonneesImmat()
        {
            InitializeComponent();
            NouvImmats.ChargerListeNouvImmats();
            dgImat.ItemsSource = NouvImmats.nouvImats;

            comboBox2.Items.Add("Croissant");
            comboBox2.Items.Add("Décroissant");
            comboBox2.SelectedIndex = 0;

            comboBox1.Items.Add("Année");
            comboBox1.Items.Add("Nombre Immatriculations");
            comboBox1.SelectedIndex = 0;



        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedItem == "Année")
            {
                DgCAn.SortDirection = sortDirection;
            }
            else
            {
                DgCNb.SortDirection = sortDirection;
            }
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox2.SelectedItem== "Croissant")
            {
                sortDirection = ListSortDirection.Ascending;
            }
            else
            {
                sortDirection = ListSortDirection.Descending;
            }
        }
    }
}
