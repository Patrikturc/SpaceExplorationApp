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
    /// Manager user interface window
    /// </summary>
    public partial class ManagerView : Window
    {
        /// <summary>
        /// instance of database
        /// </summary>
        private Database d = Database.Instance;
        /// <summary>
        /// Default constructor initializes the window and combo boxes
        /// </summary>
        public ManagerView()
        {
            InitializeComponent();
            cmbMemberToRemove.ItemsSource = d.Members;
            cmbMemberToRemove.SelectedIndex = 0;
            cmbSelectType.ItemsSource = d.StaffTypes;
            cmbSelectType.SelectedIndex = 0;
            cmbModifyMember.ItemsSource = d.Members;
            cmbModifyMember.SelectedIndex = 0;
        }
        /// <summary>
        /// Button to display all registered users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListRegisteredUsers_Click(object sender, RoutedEventArgs e)
        {
            Display();
        }
        /// <summary>
        /// Button to Add a member from managers view, this registration type does not require administrator confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            AddPerson p = new AddPerson(cmbSelectType.SelectedItem.ToString(), true);
            p.ShowDialog();
        }
        /// <summary>
        /// Button to remove a member, Managers can not remove managers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach(People p in d.Members.ToList())
            {
                if(!(p is Manager))
                {
                    if (cmbMemberToRemove.SelectedItem.Equals(p))
                    {
                        MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure" +
                        " you would like to remove :\n" + p.ToString(), "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            string s = p.IDg;
                            foreach (var item in d.Log.ToList())
                            {
                                if (item.Key == s)
                                {
                                    d.Log.Remove(s);
                                }
                            }
                            MessageBox.Show("Success Memeber :\n" + p.ToString() + "\nWas successfully removed from the database");
                            d.Members.Remove(p);
                            return;
                        }
                    }
                }
                else if(p is Manager && cmbMemberToRemove.SelectedItem is Manager)
                {
                    MessageBox.Show("Cannot remove managers");
                }
            }
        }
        /// <summary>
        /// Button to refresh content of the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            cmbMemberToRemove.Items.Refresh();
            cmbSelectType.Items.Refresh();
            cmbModifyMember.Items.Refresh();
            txtDisplay.Clear();
            Display();
        }
        /// <summary>
        /// Button uses lambda expressions to access specific property of a member and modify it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            
            Modify((People)cmbModifyMember.SelectedItem);
            
            
        }
        /// <summary>
        /// Method allowing manager to modify members
        /// </summary>
        /// <param name="id"></param>
        private void Modify(People id)
        {
            bool lastNameCheck = Regex.IsMatch(txtNewLastName.Text, "^[a-z]*$", RegexOptions.IgnoreCase);
            if (txtNewLastName.Text == "")
            {
                MessageBox.Show("Please enter a new Last name");
            }
            else if (!lastNameCheck)
            {
                MessageBox.Show("Please use only English alphabet characters for name");
            }
            else
            {
                d.Members.Find(p => p.LName == id.LName).LName = txtNewLastName.Text;
                Display();
                MessageBox.Show("Success, Modification is implemented, please update the window to see changes");
            }
        }
        /// <summary>
        /// Displays all registered members of Space exploration app
        /// </summary>
        private void Display()
        {
            txtDisplay.Clear();
            txtDisplay.AppendText(d.DisplayMembers());
        }
        /// <summary>
        /// Returns the user to login screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
