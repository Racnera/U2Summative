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

namespace u2Summative
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAge_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
    class Contact
    {
        public string fName;
        public string lName;
        public double bDay;
        public double bMonth;
        public double bYear;
        public string email;

        public Contact(string f, string l, int y, int m, int d, string e)
        {
           
        }
    }
}
