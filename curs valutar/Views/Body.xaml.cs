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
using curs_valutar.ViewModels;

namespace curs_valutar.Views
{
    /// <summary>
    /// Interaction logic for Body.xaml
    /// </summary>
    public partial class Body : UserControl
    {
        public string OrigCurrency { get; internal set; }

        public Body()
        {
            InitializeComponent();
            currencyAbbreviations();

            //subscribe to that event from the abbreviation list
            moneyAbbreviations.SelectionChanged += new SelectionChangedEventHandler(updateAbbreviationAndValue);
        }

        public string Subject { get; internal set; }

        private int dots { get; set; } = 0;
        private Color red = Color.FromRgb(237, 28, 36);

        //a function that should validate the input field to be only numbers
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            //e.Handled = regex.IsMatch(e.Text);
            
            SolidColorBrush brush = new SolidColorBrush(red);

            foreach (var item in NumberTextBox.Text)
            {
                if(item == '.')
                {
                    dots++;
                    break;
                }
                else
                {
                    dots = 0;
                }
            }
            //if the input is not valid, set the background color of the textbox to a red color
            //to let the user know that the input is not valid and it will not be added to the box
            if (regex.IsMatch(e.Text))
            {
                NumberTextBox.Background = brush;
                e.Handled = true;
            }
            else if(dots >= 1 && e.Text == ".")
            {
                NumberTextBox.Background = brush;
                e.Handled = true;
            }
            else
            {
                NumberTextBox.Background = Brushes.White;
                e.Handled = false;
            }
            //if (regex.IsMatch(e.Text))
            //{
            //    NumberTextBox.Background = brush;
            //    e.Handled = true;
            //}else if(e.Text == "."  && (dot == true))
            //{
            //    NumberTextBox.Background = brush;
            //    e.Handled = true;
            //}
            //else
            //{  
            //    if(e.Text == ".")
            //    {
            //        dot = true;
            //    }
            //    //if the input is valid, the background should stay white
            //    NumberTextBox.Background = Brushes.White;
            //    e.Handled = false;
            //}
        }

        //i currently dont know how to populate this listbox from the viewmodel
        //and i know that the view is not supposed to do too much work
        private void currencyAbbreviations()
        {
            var list = new BodyViewModel().currencyAbbreviations;

            foreach (var item in list)
            {
                moneyAbbreviations.Items.Add(item);
            }
        }

        //make a custom event listener so i can update the selected value from the abbreviation list
        //and display it to the view
        private void updateAbbreviationAndValue(object sender, SelectionChangedEventArgs e)
        {
            var dict = new BodyViewModel().d;
            selectedValue.Text = moneyAbbreviations.SelectedItem.ToString();
            moneyValue.Text = dict[moneyAbbreviations.SelectedItem.ToString()].ToString();
            //selectedValue.Text = dict[moneyAbbreviations.SelectedItem.ToString()].ToString();
            //MessageBox.Show("clicked");
        }

        private void CheckSpaceBar(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                NumberTextBox.Background = new SolidColorBrush(red);
                MessageBox.Show("spacebar");
                e.Handled = true;
            }
            if(e.Key == Key.Back)
            {
                MessageBox.Show("backspace");
                NumberTextBox.Background = Brushes.White;
                e.Handled = false;
            }
        }
    }
}
