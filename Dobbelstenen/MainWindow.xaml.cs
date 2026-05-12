using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dobbelstenen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rng = new Random();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public int[] RollDices()
        {
            int[] dicesRolled = new int[2];

            dicesRolled[0] = rng.Next(1, 7);
            dicesRolled[1] = rng.Next(1, 7);

            return dicesRolled;
        }

        public void DisplayDices(int[] rolledDices)
        {
            int image1 = rolledDices[0];
            int image2 = rolledDices[1];

            firstDiceImage.Source = new BitmapImage(new Uri($"Images/dice-{image1}.png", UriKind.Relative));
            firstDiceImage.Stretch = Stretch.Uniform;

            secondDiceImage.Source = new BitmapImage(new Uri($"Images/dice-{image2}.png", UriKind.Relative));
            secondDiceImage.Stretch = Stretch.Uniform;
        }

        private void OnRollOnceClicked(object sender, RoutedEventArgs e)
        {
            int[] rolledDices = RollDices();
            DisplayDices(rolledDices);            
        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Wil je afsluiten?", "Afsluiten", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}