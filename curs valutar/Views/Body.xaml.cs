﻿using System;
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
        public string Subject { get; internal set; }

        private int dots { get; set; } = 0;
        private Color red = Color.FromRgb(237, 28, 36);

        public Body()
        {
            InitializeComponent();
            //subscribe to that event from the abbreviation list
            moneyAbbreviations.SelectionChanged += new SelectionChangedEventHandler(updateAbbreviationAndValue);
            currencyAbbreviations();

        }

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

            if (moneyAbbreviations.SelectedItem == null)
            {
                moneyAbbreviations.Focus();
                moneyAbbreviations.SelectedItem = moneyAbbreviations.Items[0];
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

        //this event helps solve a bug that i found by accident
        //if i were to press the spacebar while NumberTextBox was selected, it would add inside it
        //whitespaces and obviously i dont want that to happen, so this event triggers everytime a press a key
        //the event type is PreviewKeyDown and it lets me know of any key press before it can make any action
        private void CheckSpaceBar(object sender, KeyEventArgs e)
        {
            //if the key is space, set the background to red and set Handled to true
            //this means that the event was handled and no empty space was added to NumberTextBox
            if(e.Key == Key.Space)
            {
                NumberTextBox.Background = new SolidColorBrush(red);
                //MessageBox.Show("spacebar");
                e.Handled = true;
            }

            //if the prev key pressed is space, the background would be red and if i were to press
            //backspace, the background would still be red, so i added another thing here to reset
            //the background color
            //the Handled property is set to false because i want the action to happen
            if(e.Key == Key.Back)
            {
                //MessageBox.Show("backspace");
                NumberTextBox.Background = Brushes.White;
                e.Handled = false;
            }
        }

        //this function just gets the value of NumberTextBox, converts it to a number
        //calculates the result and displays it to the view
        private void onClickCalculate(object sender, RoutedEventArgs e)
        {
            //get the value from the numbertextbox
            var value = NumberTextBox.Text;

            //convert that amount to a float
            float amount;

            if(value == "")
            {
                ConvertedAmount.Text = "";
            }
            else
            {
                var dict = new BodyViewModel().d;
                amount = float.Parse(value);
                var result = amount * dict[moneyAbbreviations.SelectedItem.ToString()];
                ConvertedAmount.Text = result.ToString();
            }

        }
    }
}
