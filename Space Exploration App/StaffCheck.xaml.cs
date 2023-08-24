using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Space_Exploration_App
{
    /// <summary>
    /// In case of registration of staff member(Researcher or manager) this window assures the new member is not a visitor
    /// </summary>
    public partial class StaffCheck : Window
    {
        /// <summary>
        /// login name of a staff member
        /// </summary>
        string login;
        /// <summary>
        /// password of a staff member
        /// </summary>
        string pw;
        /// <summary>
        /// Type of staff member - researcher or manager
        /// </summary>
        string who;
        /// <summary>
        /// Default constructor sets who is trying to register and the login and password of the member
        /// </summary>
        /// <param name="Who"></param>
        public StaffCheck(string Who)
        {
            InitializeComponent();
            login = "Admin";
            pw = "123";
            who = Who;
        }
        /// <summary>
        /// Confirmation button checks if the insecure password and staff name matches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            bool loginCheck = Regex.IsMatch(txtLogin.Text, "^[a-z]*$", RegexOptions.IgnoreCase);
            bool pwCheck = Regex.IsMatch(txtPw.Text, "^[0-9]*$");
            if(txtLogin.Text == "" || txtPw.Text == "")
            {
                MessageBox.Show("Please enter some credentials - Hint button can help?");
            }
            else if(!loginCheck)
            {
                MessageBox.Show("Only alphabetical characters in Login field please - if you didn't you might want to click Hint button");
            }
            else if (!pwCheck)
            {
                MessageBox.Show("Only numberical characters in password field please - if you didn't you might want to click Hint button!");
            }
            else if (txtLogin.Text == login && txtPw.Text == pw)
            {

                AddPerson p = new AddPerson(who, true);
                p.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Credentials.");
            }
        }
        /// <summary>
        /// Hint for You because there is no way you can know this information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHint_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi Pete! Login is 'Admin' with capital A and Password is '123'\n\nEnjoy the app!");
        }
    }
}
