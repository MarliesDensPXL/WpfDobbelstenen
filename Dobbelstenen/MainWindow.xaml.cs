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
using System.Windows.Threading;

namespace Dobbelstenen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _rng = new Random();
        DispatcherTimer _timer = new DispatcherTimer();
        int _rolledDices = 0;
        Dictionary<int, int> _sums = new Dictionary<int, int>();
        
        public MainWindow()
        {
            InitializeComponent();
            // numberOfRollsLabel.Content = numberOfRollsSlider.Value;
        }

        public int[] RollDices()
        {
            int[] dicesRolled = new int[2];

            dicesRolled[0] = _rng.Next(1, 7);
            dicesRolled[1] = _rng.Next(1, 7);

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

        private void OnValueSliderChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (numberOfRollsLabel is not null) // moet je toevoegen omdat in de Xamlcode het label pas aangemaakt wordt ná de slider dus op het moment dat het event wordt aangeroepen (om de standaardwaarde van 0 naar 10 te wijzigen in Xaml-code) bestaat het label nog niet.
            {
                numberOfRollsLabel.Content = numberOfRollsSlider.Value.ToString();
            }
        }

        // alternatieve oplossing: de waarde van je slider pas instellen op het moment dat je venster geladen is, via Loaded-event. Op dat moment zijn alle knoppen etc gemaakt.

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            numberOfRollsSlider.Value = 10;
        }

        private void OnRollALotClicked(object sender, RoutedEventArgs e)
        {
                      

            _timer.Interval = TimeSpan.FromSeconds(0.5);                      
                _timer.Tick += Timer_Tick;
                _timer.Start();           
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int numberOfRolls = (int)numberOfRollsSlider.Value;

            if (_rolledDices < numberOfRolls)
            {
                int[] rolledDices = RollDices();
                DisplayDices(rolledDices);
                _rolledDices++;

                int sum = rolledDices[0] + rolledDices[1];

                if (!_sums.ContainsKey(sum))
                {
                    _sums.Add(sum, 1);
                }
                else
                {
                    _sums[sum] += 1;
                }

                result2TextBox.Text = (_sums.ContainsKey(2) ? _sums[2].ToString() : "0");
                result3TextBox.Text = (_sums.ContainsKey(3) ? _sums[3].ToString() : "0");
                result4TextBox.Text = (_sums.ContainsKey(4) ? _sums[4].ToString() : "0");
                result5TextBox.Text = (_sums.ContainsKey(5) ? _sums[5].ToString() : "0");
                result6TextBox.Text = (_sums.ContainsKey(6) ? _sums[6].ToString() : "0");
                result7TextBox.Text = (_sums.ContainsKey(7) ? _sums[7].ToString() : "0");
                result8TextBox.Text = (_sums.ContainsKey(8) ? _sums[8].ToString() : "0");
                result9TextBox.Text = (_sums.ContainsKey(9) ? _sums[9].ToString() : "0");
                result10TextBox.Text = (_sums.ContainsKey(10) ? _sums[10].ToString() : "0");
                result11TextBox.Text = (_sums.ContainsKey(11) ? _sums[11].ToString() : "0");
                result12TextBox.Text = (_sums.ContainsKey(12) ? _sums[12].ToString() : "0");
                
            }
            else
            {
                _timer.Stop();
            }

        }
    }
}