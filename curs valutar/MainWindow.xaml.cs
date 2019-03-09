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
using curs_valutar.ApiCall;

namespace curs_valutar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Parser parser = new Parser();
        static Dictionary<string,float> dict = parser.getCubes();
        public MainWindow()
        {
            InitializeComponent();
            moneyAbbreviations.SelectionChanged += new SelectionChangedEventHandler(test);
            
            var header = parser.getHeaderData();

            publisherName.Text = header[0];
            date.Text = header[1];
            

            foreach (var item in dict)
            {
                moneyAbbreviations.Items.Add(item.Key);
            }

            if(moneyAbbreviations.SelectedItem == null)
            {
                moneyAbbreviations.SelectedItem = moneyAbbreviations.Items[0];
            }

            

        }

        private void test(object sender, SelectionChangedEventArgs e)
        {
            moneyValue.Text = dict[moneyAbbreviations.SelectedItem.ToString()].ToString();
            //MessageBox.Show("clicked");
        }


    }


}
