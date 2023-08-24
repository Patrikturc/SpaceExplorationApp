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
    /// Login window uses secure login to allow registered users access to different parts of the Space Exploration App
    /// </summary>
    [Serializable]
    public partial class Login : Window
    {
        /// <summary>
        /// Instance of Database
        /// </summary>
        private Database d = Database.Instance;
        /// <summary>
        /// Login window takes type of staff registering as a parameter
        /// </summary>
        /// <param name="t">Who is trying to register</param>
        public Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Button that attempts to log the user in into appropriate user interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SecureLogin();
        }
        /// <summary>
        /// Secure Login method checks who is attempting to login 
        /// allowing the appropriate user interface to be displayed 
        /// given the entered credentials are correct.
        /// </summary>
        private void SecureLogin()
        {
            string uName = txtVId.Text;
            char[] typeC = uName.ToCharArray();
            string type = typeC[0].ToString();
            SecureString pw = txtVPw.SecurePassword;
            foreach (KeyValuePair<string, SecureString> ex in d.Log)
            {
                if (ex.Key.Equals(uName) && IsEqualTo(ex.Value, pw))
                {
                    switch (type)
                    {
                        case "v":
                            MessageBox.Show("Welcome " + d.Members.Find(p => p.IDg == uName).FName.ToString());
                            VisitorView vV = new VisitorView();
                            vV.ShowDialog();
                            break;

                        case "r":
                            MessageBox.Show("Welcome " + d.Members.Find(p => p.IDg == uName).FName.ToString());
                            ResearcherView rV = new ResearcherView();
                            rV.ShowDialog();
                            break;

                        case "m":
                            MessageBox.Show("Welcome " + d.Members.Find(p => p.IDg == uName).FName.ToString());
                            ManagerView mV = new ManagerView();
                            mV.ShowDialog();
                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
            MessageBox.Show("Incorrect credentials");
        }
        /// <summary>
        /// Method that is capable of comparing 2 secure string and can evaluate if they are equal
        /// </summary>
        /// <param name="pwInMemory">Password in memory</param>
        /// <param name="pwEntered">Password the user had entered</param>
        /// <returns>true if equal, false if password doesn't match</returns>
        private bool IsEqualTo(SecureString pwInMemory, SecureString pwEntered)
        {
            IntPtr bstr1 = IntPtr.Zero;
            IntPtr bstr2 = IntPtr.Zero;
            try
            {
                bstr1 = Marshal.SecureStringToBSTR(pwInMemory);
                bstr2 = Marshal.SecureStringToBSTR(pwEntered);
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
        /// <summary>
        /// Button to return to Main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
