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
    /// UI for Visitor member
    /// </summary>
    public partial class VisitorView : Window
    {
        /// <summary>
        /// Database instance
        /// </summary>
        private Database d = Database.Instance;
        /// <summary>
        /// Default constructor for visitor UI, initializes the window and assigns value to combo boxes
        /// </summary>
        public VisitorView()
        {
            InitializeComponent();
            cmbPlanetType.ItemsSource = d.PlanetTypes;
        }
        /// <summary>
        /// Displays all discovered star systems for Visitor inside the display text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayStars_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Clear();
            txtDisplay.AppendText(d.DisplayStars());
        }
        /// <summary>
        /// Displays all discovered planets for visitor inside the display text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayPlanets_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Clear();
            txtDisplay.AppendText(d.DisplayPlanets());
        }
        /// <summary>
        /// Displays information about specific type of a planet for visitor inside display text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayInfo_Click(object sender, RoutedEventArgs e)
        {
            Display(cmbPlanetType.Text);
        }
        /// <summary>
        /// Display method for displayinfo button
        /// </summary>
        /// <param name="pType"></param>
        private void Display(string pType)
        {
            txtDisplay.Clear();
            switch (pType)
            {
                case "Rocky Planet":
                    txtDisplay.AppendText("A terrestrial planet, telluric planet, or rocky planet is a planet that is composed primarily " +
                        "of silicate rocks or metals. Within the Solar System, the terrestrial planets are the inner " +
                        "planets closest to the Sun, i.e. Mercury, Venus, Earth, and Mars.");
                    break;
                case "Super-Earth":
                    txtDisplay.AppendText("A super-Earth is an extrasolar planet with a mass higher than Earth's, but substantially " +
                        "below those of the Solar System's ice giants, Uranus and Neptune, which are 14.5 and 17 times Earth's, " +
                        "respectively. \nThe term super - Earth refers only to the mass of the planet, and so does not imply anything " +
                        "about the surface conditions or habitability. The alternative term gas dwarfs may be more accurate for those at " +
                        "the higher end of the mass scale.");
                    break;
                case "Mini-Neptune":
                    txtDisplay.AppendText("A mini-Neptune is a planet less massive than Neptune but resembles Neptune in" +
                        " that it has a thick hydrogen–helium atmosphere, probably with deep layers of ice, rock or liquid oceans.");
                    break;
                case "Ice Giant":
                    txtDisplay.AppendText("An ice giant is a giant planet composed mainly of elements heavier than hydrogen and helium, " +
                        "such as oxygen, carbon, nitrogen, and sulfur. There are two ice giants in the Solar System: Uranus and Neptune.");
                    break;
                case "Gas Giant":
                    txtDisplay.AppendText("A gas giant is a giant planet composed mainly of hydrogen and helium. Gas giants are sometimes " +
                        "known as failed stars because they contain the same basic elements as a star. " +
                        "Jupiter and Saturn are the gas giants of our Solar System.");
                    break;
            }
        }
        /// <summary>
        /// Logout button for Visitor, returns the member to login view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
