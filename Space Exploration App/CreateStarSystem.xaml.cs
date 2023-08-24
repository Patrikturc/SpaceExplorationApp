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
    /// Window used to create a new star system
    /// </summary>
    public partial class CreateStarSystem : Window
    {
        /// <summary>
        /// Instance of the main database
        /// </summary>
        Database d = Database.Instance;
        public CreateStarSystem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Button to add a star to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddStar_Click(object sender, RoutedEventArgs e)
        {
            //Star names often can be a composition of symbols and numbers, for that reason I will allow Star Name field to contain them
            bool temperatureCheck = Regex.IsMatch(txtTemp.Text, "^[0-9]*$");
            bool distanceCheck = Regex.IsMatch(txtDist.Text, "^[0-9]*$");
            if(txtStarName.Text == "" || txtTemp.Text == "" || txtDist.Text == "")
            {
                MessageBox.Show("All fields must contain information");
            }
            else if (!temperatureCheck || !distanceCheck)
            {
                MessageBox.Show("Only numerical values in temperature and distance field please");
            }
            else
            {
                StarSystem sS1 = new StarSystem(txtStarName.Text, int.Parse(txtTemp.Text), int.Parse(txtDist.Text));
                MessageBox.Show("Success!\nStar System : " + txtStarName.Text + " Added to database");
            }
        }
        /// <summary>
        /// Button to return to researcher view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
