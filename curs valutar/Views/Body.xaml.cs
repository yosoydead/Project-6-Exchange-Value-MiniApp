using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace curs_valutar.Views
{
    /// <summary>
    /// Interaction logic for Body.xaml
    /// </summary>
    public partial class Body : UserControl
    {
        public Body()
        {
            InitializeComponent();
        }

        //a function that should validate the input field to be only numbers
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            //e.Handled = regex.IsMatch(e.Text);

            //if the input is not valid, set the background color of the textbox to a red color
            //to let the user know that the input is not valid and it will not be added to the box
            if (regex.IsMatch(e.Text))
            {
                var red = Color.FromRgb(237, 28, 36);
                SolidColorBrush brush = new SolidColorBrush(red);
                NumberTextBox.Background = brush;
                e.Handled = true;
            }
            else
            {
                //if the input is valid, the background should stay white
                NumberTextBox.Background = Brushes.White;
                e.Handled = false;
            }
        }
    }
}
