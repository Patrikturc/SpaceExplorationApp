using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
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
    /// Class allowing addition of new members to the database
    /// </summary>
    public partial class AddPerson : Window
    {
        /// <summary>
        /// Who string determines type of a member that is attempting to register
        /// </summary>
        private string Who;
        /// <summary>
        /// id makes each member unique
        /// </summary>
        private static int id;
        /// <summary>
        /// Default constructor setting id to 1000 so it can be incremented from then
        /// </summary>
        public AddPerson()
        {
            id = 1000;
        }
        /// <summary>
        /// Main constructor of AddPerson class, it selects correct layout of registration window and checks if member who is trying to register is 
        /// a staff member or a visitor
        /// </summary>
        /// <param name="who">Insert type of member (Manager, Visitor or Researcher)</param>
        /// <param name="Checked">true if visitor, false if Staff member</param>
        public AddPerson(string who, bool Checked)
        {
            
            InitializeComponent();
            Who = who;
            this.Visibility = Visibility.Hidden;
            CanvasVisitor.Visibility = Visibility.Hidden;
            CanvasPayroll.Visibility = Visibility.Hidden;
            CanvasReseacher.Visibility = Visibility.Hidden;
            if (who == "Visitor")
            {
                CanvasVisitor.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Visible;
                Height = 180;

            }
            else if (!Checked)
            {
                StaffCheck s = new StaffCheck(who);
                s.ShowDialog();
                return;
            }
            else if (who == "Manager")
            {
                CanvasPayroll.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Visible;
            }
            else 
            {
                CanvasReseacher.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Visible;
            }
            
            
            
        }
        /// <summary>
        /// Button that Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Button to create a new member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            
            bool firstNameCheck = Regex.IsMatch(txtFirstName.Text, "^[a-z]*$", RegexOptions.IgnoreCase);
            bool lastNameCheck = Regex.IsMatch(txtLastName.Text, "^[a-z]*$", RegexOptions.IgnoreCase);
            bool townCheck = Regex.IsMatch(txtPTown.Text, "^[a-z]*$", RegexOptions.IgnoreCase);
            bool postCodeCheck = Regex.IsMatch(txtPPostcode.Text, "^[a-zA-Z0-9]*$");
            bool streetCheck = Regex.IsMatch(txtPStreet.Text, "^[a-zA-Z 0-9]*$");
            bool yearCheck = Regex.IsMatch(txtPYear.Text, "^(0|[1-9][0-9]+)$");
            bool depIdCheck = Regex.IsMatch(txtDepartmentId.Text, "^[0-9]*$");
            bool rTownCheck = Regex.IsMatch(txtRTown.Text, "^[a-z]*$", RegexOptions.IgnoreCase);
            bool rPostCodeCheck = Regex.IsMatch(txtRPostcode.Text, "^[a-zA-Z0-9]*$");
            bool rStreetCheck = Regex.IsMatch(txtRStreet.Text, "^[a-zA-Z 0-9]*$");
            bool rYearCheck = Regex.IsMatch(txtRYear.Text, "^(0|[1-9][0-9]+)$");
            bool rTopicCheck = Regex.IsMatch(txtResearchTopic.Text, "^[a-z ]*$", RegexOptions.IgnoreCase);

            if (Who == "Visitor")
            {
                if (txtFirstName.Text == "" || txtLastName.Text == "" || txtVPwBox.SecurePassword.Length == 0 || txtVConfirmPwBox.SecurePassword.Length == 0)
                {
                    MessageBox.Show("All fields with * are mandatory.");
                }
                else if (!lastNameCheck || !firstNameCheck)
                {
                    MessageBox.Show("Please use only English alphabet characters for name");
                }
                else if (txtVPwBox.SecurePassword.Length <= 2 || txtVConfirmPwBox.SecurePassword.Length <= 2)
                {
                    MessageBox.Show("Password must be at least 3 characters long");
                }
                else if (!IsEqualTo(txtVPwBox.SecurePassword, txtVConfirmPwBox.SecurePassword))
                {
                    MessageBox.Show("Passwords do not match");
                }
                else
                {
                    Visitor v;
                    v = new Visitor(txtFirstName.Text, txtLastName.Text, ++id, txtVPwBox.SecurePassword);
                    MessageBox.Show("Thank you for registering, your ID is : '" + v.VId + "' Please make a note of it");
                    this.Close();
                }
            }
            if (Who == "Manager")
            {
                CanvasPayroll.Visibility = Visibility.Visible;
                if (txtFirstName.Text == "" || txtLastName.Text == "" || txtPPwBox.SecurePassword.Length == 0 || txtPPwConfBox.SecurePassword.Length == 0 || txtPPostcode.Text == "" || txtPStreet.Text == "" || 
                    txtPTown.Text == "" || txtPYear.Text == "" || txtDepartmentId.Text == "")
                {
                    MessageBox.Show("All fields with * are mandatory.");
                }
                else if (!lastNameCheck || !firstNameCheck)
                {
                    MessageBox.Show("Please use only English alphabet characters for name");
                }
                else if (txtPPwBox.SecurePassword.Length <= 2 || txtPPwConfBox.SecurePassword.Length <= 2)
                {
                    MessageBox.Show("Password must be at least 3 characters long");
                }
                else if (!postCodeCheck || !streetCheck)
                {
                    MessageBox.Show("Please use only English alphabet and numbers for Postcode and street");
                }
                else if (!yearCheck)
                {
                    MessageBox.Show("Only numerical values in Year field please");
                }
                else if (txtPPostcode.Text.Length < 6 || txtPPostcode.Text.Length > 8)
                {
                    MessageBox.Show("Postcode needs to be between 6 and 8 characters long");
                }
                
                else if (int.Parse(txtPYear.Text) < 1903 || int.Parse(txtPYear.Text) > 2016 || txtPYear.Text.Length != 4)
                {
                    MessageBox.Show("Year must be between 1903 and 2016 and in format YYYY");
                }
                
                else if (!depIdCheck)
                {
                    MessageBox.Show("Only numerical values in Department ID field please");
                }
                else if (!townCheck)
                {
                    MessageBox.Show("Only Alphabetical characters in Town field please");
                }
                else if (!IsEqualTo(txtPPwBox.SecurePassword, txtPPwConfBox.SecurePassword))
                {
                    MessageBox.Show("Passwords do not match");
                }
                else
                {
                    Manager m = new Manager(txtFirstName.Text, txtLastName.Text, txtPTown.Text, txtPStreet.Text, txtPPostcode.Text,
                    ushort.Parse(txtPYear.Text), ++id, ushort.Parse(txtDepartmentId.Text), txtPPwBox.SecurePassword);
                    MessageBox.Show("Thank you for registering, your ID is : '" + m.IDg + "' Please make a note of it");
                    this.Close();
                }
                
                

            }
            if (Who == "Researcher")
            {
                CanvasReseacher.Visibility = Visibility.Visible;
                if (txtFirstName.Text == "" || txtLastName.Text == "" || txtRPwBox.SecurePassword.Length == 0 || txtRPwConfBox.SecurePassword.Length == 0 || txtRPostcode.Text == "" || txtRStreet.Text == "" ||
                    txtRTown.Text == "" || txtRYear.Text == "" || txtResearchTopic.Text == "")
                {
                    MessageBox.Show("All fields with * are mandatory.");
                }
                else if (!lastNameCheck || !firstNameCheck)
                {
                    MessageBox.Show("Please use only English alphabet characters for name");
                }
                else if (txtRPwBox.SecurePassword.Length <= 2 || txtRPwConfBox.SecurePassword.Length <= 2)
                {
                    MessageBox.Show("Password must be at least 3 characters long");
                }
                else if (!rPostCodeCheck || !rStreetCheck)
                {
                    MessageBox.Show("Please use only English alphabet and numbers for Postcode and street");
                }
                else if (!rYearCheck)
                {
                    MessageBox.Show("Only numerical values in Year field please");
                }
                else if (txtRPostcode.Text.Length < 6 || txtRPostcode.Text.Length > 8)
                {
                    MessageBox.Show("Postcode needs to be between 6 and 8 characters long");
                }

                else if (int.Parse(txtRYear.Text) < 1903 || int.Parse(txtRYear.Text) > 2016 || txtRYear.Text.Length != 4)
                {
                    MessageBox.Show("Year must be between 1903 and 2016 and in format YYYY");
                }

                else if (!rTopicCheck)
                {
                    MessageBox.Show("Only alphabetical values in Research topic field please");
                }
                else if (!rTownCheck)
                {
                    MessageBox.Show("Only Alphabetical characters in Town field please");
                }
                else if (!IsEqualTo(txtRPwBox.SecurePassword, txtRPwConfBox.SecurePassword))
                {
                    MessageBox.Show("Passwords do not match");
                }
                else
                {
                    Researcher r;
                    r = new Researcher(txtFirstName.Text, txtLastName.Text, txtRTown.Text, txtRStreet.Text, txtRPostcode.Text,
                        ushort.Parse(txtRYear.Text), ++id, txtResearchTopic.Text, txtRPwBox.SecurePassword);
                    MessageBox.Show("Thank you for registering, your ID is : '" + r.RId + "' Please make a note of it");
                    this.Close();
                }
                
            }
        }
        /// <summary>
        /// Checks 2 different Secure Strings, if they are a match returns true
        /// in other case returns false
        /// </summary>
        /// <param name="ss1"></param>
        /// <param name="ss2"></param>
        /// <returns></returns>
        private bool IsEqualTo(SecureString ss1, SecureString ss2)
        {
            IntPtr bstr1 = IntPtr.Zero;
            IntPtr bstr2 = IntPtr.Zero;
            try
            {
                bstr1 = Marshal.SecureStringToBSTR(ss1);
                bstr2 = Marshal.SecureStringToBSTR(ss2);
                int length1 = Marshal.ReadInt32(bstr1, -4);
                int length2 = Marshal.ReadInt32(bstr2, -4);
                if (length1 == length2)
                {
                    for (int x = 0; x < length1; ++x)
                    {
                        byte b1 = Marshal.ReadByte(bstr1, x);
                        byte b2 = Marshal.ReadByte(bstr2, x);
                        if (b1 != b2) return false;
                    }
                }
                else return false;
                return true;
            }
            finally
            {
                if (bstr2 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr2);
                if (bstr1 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr1);
            }
        }
    }
}
