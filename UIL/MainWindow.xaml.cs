using System.Windows;
using System.Windows.Controls;

namespace UIL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserControl ContenuEcran { get; set; }
        public UCInitial Initial = new UCInitial();
        public UCDonneesImmat DonnesImat = new UCDonneesImmat();
        public MainWindow()
        {
            InitializeComponent();
            ContenuEcran = Initial;
            Grid.SetRow(ContenuEcran, 1);
            Grid.SetColumn(ContenuEcran, 0);
            gPrincipal.Children.Add(ContenuEcran);

        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {


            var result = MessageBox.Show("Voulez-vous bien quitter ?", "Quitter",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Question);


            if (result == MessageBoxResult.No)
            {
                return;
            }

            Close();



        }

        private void Donnes_Click(object sender, RoutedEventArgs e)
        {
            gPrincipal.Children.Remove(ContenuEcran);
            ContenuEcran = DonnesImat;
            Grid.SetRow(ContenuEcran, 1);
            Grid.SetColumn(ContenuEcran, 0);
            gPrincipal.Children.Add(ContenuEcran);
        }
    }

}
