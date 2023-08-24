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
using System.Windows.Shapes;

namespace Space_Exploration_App
{
    /// <summary>
    /// Window used to create new planets
    /// </summary>
    public partial class AddPlanets : Window
    {
        /// <summary>
        /// Name of the new Star
        /// </summary>
        private string starName;
        /// <summary>
        /// Instance of main Database
        /// </summary>
        private Database d = Database.Instance;
        /// <summary>
        /// Constructor that receives stars name as a parameter and sets it, it initializes combo boxes
        /// </summary>
        /// <param name="sName"></param>
        public AddPlanets(string sName)
        {
            InitializeComponent();
            starName = sName;
            cmbZone.ItemsSource = d.Zones;
            cmbZone.SelectedIndex = 0;
            cmbType.ItemsSource = d.PlanetTypes;
            cmbType.SelectedIndex = 0;
        }
        /// <summary>
        /// Button to add a planet to database, uses text fields and combo boxes to identify variables values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Planet p = new Planet(starName, txtName.Text, (string)cmbType.SelectedItem, (string)cmbZone.SelectedItem);
            MessageBox.Show("Success, planet: \n" + p.ToString() + "\nAdded to the database");
        }
        /// <summary>
        /// button to return to researcher view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
