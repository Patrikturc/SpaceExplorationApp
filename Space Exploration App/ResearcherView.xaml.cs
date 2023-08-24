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
    /// Researcher UI window
    /// </summary>
    public partial class ResearcherView : Window
    {
        Database d = Database.Instance;
        /// <summary>
        /// ResearcherView Constructor initializes UI, Displays current entries and initializes 
        /// data combo boxes will display when the window is open
        /// </summary>
        public ResearcherView()
        {
            InitializeComponent();
            txtDisplay.AppendText(d.DisplayStars());
            cmbAssignPlanet.ItemsSource = d.StarS;
            cmbPlanetToRemove.ItemsSource = d.Planets;
            cmbRemoveStar.ItemsSource = d.StarS;
            cmbModifyZone.ItemsSource = d.Planets;
            cmbModifyTo.ItemsSource = d.Zones;
            cmbAssignPlanet.SelectedIndex = 0;
            cmbPlanetToRemove.SelectedIndex = 0;
            cmbRemoveStar.SelectedIndex = 0;
            cmbModifyZone.SelectedIndex = 0;
            cmbModifyTo.SelectedIndex = 0;
        }
        /// <summary>
        /// Button that allows researcher to add a new Star/Star System
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSystem_Click(object sender, RoutedEventArgs e)
        {
            CreateStarSystem cSs = new CreateStarSystem();
            cSs.ShowDialog();
        }
        /// <summary>
        /// Button to display all entries within the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Clear();
            txtDisplay.AppendText(d.DisplayStars());
        }
        /// <summary>
        /// Button to create and assign planet to a star system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAssignPlanets_Click(object sender, RoutedEventArgs e)
        {
            AddPlanets a = new AddPlanets(cmbAssignPlanet.Text);
            a.ShowDialog();
        }
        /// <summary>
        /// Button that will iterate through the list of planets and display all planets discovered regardless what star they orbit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayPlanets_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Clear();
            txtDisplay.AppendText(d.DisplayPlanets());
            
        }
        /// <summary>
        /// This button allows researcher to remove a specific planet from database
        /// It will display all planets stored inside the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemovePlanet_Click(object sender, RoutedEventArgs e)
        {
            foreach(Planet p in d.Planets.ToList())
            {
                if(p == cmbPlanetToRemove.SelectedItem)
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure" +
                    " you would like to remove :\n" + p.ToString(), "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        d.Planets.Remove(p);
                        txtDisplay.Clear();
                        txtDisplay.AppendText(d.DisplayStars());
                        MessageBox.Show("Planet :\n" + p.ToString() + "\n was successfully removed from the database");
                    }
                }
            }
        }
        /// <summary>
        /// An update button which will refresh all combo boxes and display updated entries
        /// in the display text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            cmbAssignPlanet.Items.Refresh();
            cmbPlanetToRemove.Items.Refresh();
            cmbRemoveStar.Items.Refresh();
            cmbModifyZone.Items.Refresh();
            cmbModifyTo.Items.Refresh();
            cmbAssignPlanet.SelectedIndex = 0;
            cmbPlanetToRemove.SelectedIndex = 0;
            cmbRemoveStar.SelectedIndex = 0;
            cmbModifyZone.SelectedIndex = 0;
            cmbModifyTo.SelectedIndex = 0;
            txtDisplay.Clear();
            txtDisplay.AppendText(d.DisplayStars());
        }
        /// <summary>
        /// Button allowing researcher to remove a star system including it's assigned planets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveStar_Click(object sender, RoutedEventArgs e)
        {
            foreach(StarSystem sS in d.Stars.ToList())
            {
                if (d.Stars.IndexOf(sS) == cmbRemoveStar.SelectedIndex)
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure" +
                    " you would like to remove :\n" + sS.ToString(), "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (Planet p in d.Planets.ToList())
                        {
                            if (p.StarName == cmbRemoveStar.SelectedItem.ToString())
                            {
                                d.Planets.Remove(p);
                            }
                        }
                        d.Stars.Remove(sS);
                        d.StarS.Remove(cmbRemoveStar.SelectedItem.ToString());
                        txtDisplay.Clear();
                        txtDisplay.AppendText(d.DisplayStars());
                        MessageBox.Show("Success, Star System :\n" + sS.ToString() + "\n was successfully removed from the database");
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Button allowing the researcher to modify zone of planets orbit in case initial data were incorrect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyZone_Click(object sender, RoutedEventArgs e)
        {
            Modify((Planet)cmbModifyZone.SelectedItem);
            txtDisplay.Clear();
            txtDisplay.AppendText(d.DisplayStars());
            MessageBox.Show("Success, Modification is implemented, please update the window to see changes");
        }
        /// <summary>
        /// A modify method used by button to modify planets orbit zone
        /// </summary>
        /// <param name="pl"></param>
        private void Modify(Planet pl)
        {
            d.Planets.Find(p => p.Zone == pl.Zone).Zone = (string)cmbModifyTo.SelectedItem;
        }
        /// <summary>
        /// Logout button which closes researcher UI and returns the user to Login view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
