/*Ethan Hunter 314243
 *3/29/2019
 *goal is to make the worst and stupidest contact program possible. 
 *Actuall purpose is to test our understanding of unit 2, such as classes, encapsulation and "catch try"*/
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
        int[] dateHold = new int[3];   //holds the date in the Contact, used later has 3 places.
        Contact c = new Contact();     //placed here to allow c to be used in "Window.Closing"

        public MainWindow()
        {
            InitializeComponent();

            txtIn.Text = c.ReadFromFile();    //text in textbox is set to the contents of the .txt file
            string[] inSplit = txtIn.Text.Split(',');  //splits the textbox content at the commas
            int counter = 0;  //counters used to check if all the Contact's criteria is present
            int sCounter = 0; // ^^^^

            for (int i = 0; i < inSplit.Length; i++)   //loops through inSplit and checks if strings and integers are present
            {
                bool b = Int32.TryParse(inSplit[i], out Int32 result); //checks if the value in inSplit at the #number of times the loop has been passed
                if (b == true)
                {
                    dateHold[counter] = Int32.Parse(inSplit[i]);   //adds the number to dateHold in the place of counter
                    counter++;     //only adds if b is an integer, allows the value of inSplit[i] to be placed in dateHold at "counter", 
                                   //counter increases to place the next integer into the next slot.
                }
                else { sCounter++; }; //sCounter checks the amount of strings in inSplit
            }

            if (counter != 3) //if there aren't 3 numbers
            {
                MessageBox.Show("Oops! Soimething went wrong! \nPlease fix the text file. \nAre all values in your birthday present? \nDo you have extra information?");
                Environment.Exit(0);//closes the program 
            }

            if (sCounter != 3)//if there arent 3 strings
            {
                MessageBox.Show("Oops! Soimething went wrong! \nPlease fix the text file. \nAre the first name, last name and email present? \nDo you have extra information?");
                Environment.Exit(0);//closes the program
            }
        }


        private void btnAge_Click(object sender, RoutedEventArgs e)
        {
            //some code here is the same as above, its repeated in order to check the age everytime the button is clicked, its used above to check if the .txt can be used. 
            string[] inSplit = txtIn.Text.Split(',');
            int counter = 0;

            for (int i = 0; i < inSplit.Length; i++)
            {
                bool b = Int32.TryParse(inSplit[i], out Int32 result);
                if (b == true)
                {
                    dateHold[counter] = Int32.Parse(inSplit[i]);
                    counter++;
                }
                
            }

            if (counter != 3) { MessageBox.Show("Oops! Soimething went wrong! \nPlease fix the text file. \nAre all values in your birthday present?"); } //if there aren't 3 numbers as the button is clicked
            else 
            {
                DateTime Bday = new DateTime(dateHold[0], dateHold[1], dateHold[2]);    //converts integers in dateHold to a DateTime
                string age = (DateTime.Today - Bday).ToString();                        //shows the age in days:hours:Minutes:seconds, whoops.
                string[] xSplit = age.Split(':');                                       //gets the age in days away from all other useless information
                double x = double.Parse(xSplit[0]);                                     //changes the age in days from string to integer
                MessageBox.Show(Math.Floor(x / 365).ToString() + " Years Old");         //divides age in days to age in years, shows it to the user.
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int sCounter = 0;                                               //checks if all necessary values are present in order to be re-opened, saves when the window is closed.
            string[] inSplit = txtIn.Text.Split(',');
            int counter = 0;
            for (int i = 0; i < inSplit.Length; i++)
            {
                bool b = Int32.TryParse(inSplit[i], out Int32 result);
                if (b == true)
                {
                    dateHold[counter] = Int32.Parse(inSplit[i]);
                    counter++;
                }
                else { sCounter++; };
            }
            if (counter != 3)
            {
                MessageBox.Show("Oops! Soimething went wrong! \nPlease fix the text file. \nAre all values in your birthday present?");
                e.Cancel=true; //cancels the close so user can fix information
            }          
            if (sCounter != 3)
            {
                MessageBox.Show("Oops! Soimething went wrong! \nPlease fix the text file. \nAre the first name, last name and email present?");
                e.Cancel=true; //cancels the close so user can fix information
            }
            try
            {
                c.SaveToFile(txtIn.Text); //txtIn is the textbox
            }
            catch (Exception ex) {MessageBox.Show(ex.Message);} //incase you mess with something and can't access the file.
        }
    }
    public class Contact    //class allows program to write and read the file
    {
        private string filecontent;
        private StreamWriter writer;

        public string ReadFromFile()   
        {
            try
            {
                StreamReader sr = new StreamReader("contact.txt");
                while (!sr.EndOfStream)
                {
                    filecontent = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); } //incase you mess with something and can't access the file, or it doesn't exist.
            return filecontent;
        }

        public StreamWriter SaveToFile(string input)    //where you pull the text from, in this case its from "txtIn"
        {
            try
            {
                StreamWriter wr = new StreamWriter("contact.txt");
                wr.WriteLine(input);
                wr.Flush();
                wr.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); } //incase you mess with something and can't access the file, or it doesn't exist.
            return writer;    //i needed this inorder to not loop forever, it actually does nothing.
        }
        public Contact() { }//allows "contact c = new Contact()" to work, thus allowing c.ReadFromFile() and c.WriteToFile(input) to work.

    }
}

