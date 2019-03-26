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
using System.IO;
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
            int temp = 1;
            Start:
                Contact c = new Contact();
                txtIn.Text = c.ReadFromFile();
                StreamReader sr = new StreamReader("Contact.txt");
                string[] inSplit = txtIn.Text.Split(',');
                int counter = 0;
                
                for (int i = 0; i >= inSplit.Length; i++)
                {
                bool b = Int32.TryParse(inSplit[i], out Int32 result);
                    if (b == true)
                    {
                        counter++;
                    }
                MessageBox.Show(counter.ToString());
                }
                if (counter != 3) { MessageBox.Show("OOps! Soimething went wrong!"); goto Start; }
                if (counter == 3) { MessageBox.Show("Nega"); }

        }

        private void btnAge_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class Contact
    {
        string filecontent;
        string[] conSplit;

        public string ReadFromFile()
        {
            StreamReader sr = new StreamReader("Contact.txt");
            while (!sr.EndOfStream)
            {
                filecontent = sr.ReadLine();

            }
            return filecontent;
        }


        public Contact(string f, string l, int y, int m, int d, string e)
        {
            conSplit = filecontent.Split(',');
            f = conSplit[0];
            l = conSplit[1];
            y = Int32.Parse(conSplit[2]);
            m = Int32.Parse(conSplit[3]);
            d = Int32.Parse(conSplit[4]);
            e = conSplit[5];
        }
        public Contact(string f, string l, string e)
        {

        }
        public Contact(string f, string l)
        {

        }
        public Contact() { }

    }
}

