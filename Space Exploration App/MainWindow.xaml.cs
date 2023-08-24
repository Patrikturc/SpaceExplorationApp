using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
/// <summary>
/// ***************************************************************************************************************
/// Version : 1.0
/// Author : Patrik Turcani
/// Basic info:
/// _____________________________________________________________________________________________
/// This app is designed to be simple and neatly looking
/// It allows a new user to register as a Visitor or a staff member to register as a Manager or Researcher
/// Users Passwords are securely handled and each user has appropriate UI
/// Explore the app to discover what it has to offer and feel free to create your own Star Systems/Planets database
/// Enjoy. 
/// In a newer version I would be looking forward to implementing ability to save registered users and their login 
/// whenever the app closes and load this information when the app opens. Of course same for Planets and stars.
/// _____________________________________________________________________________________________
/// Read Me:
/// To Register as a staff member please use username 'Admin', Password '123'
/// Newly registered members receive username : x1001 where x = type of staff member (e.g v for Visitor), every 
/// other member registered afterwards incrememts the ID by 1
/// ***************************************************************************************************************
/// </summary>
namespace Space_Exploration_App
{
    /// <summary>
    /// Main window class
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Instance of database
        /// </summary>
        private Database d = Database.Instance;
        /// <summary>
        /// Initializes ID
        /// </summary>
        private AddPerson aP = new AddPerson();
        /// <summary>
        /// Main window default constructor, initializes the window and populating lists with default content.
        /// I hoped for this application to be able to store the database on an external database or at least a file
        /// I will try to impliment this when I can
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                if (!File.Exists("Space exploration.dat"))
                {
                    //PopulateLists(); 
                }
                else
                {

                    IFormatter nformatter = new BinaryFormatter();
                    Stream nstream = new FileStream("Space exploration.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
                    d = (Database)nformatter.Deserialize(nstream);
                    nstream.Close();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            
            PopulateLists();
            whoCombo.ItemsSource = d.StaffTypes;
            whoCombo.SelectedIndex = 0;
        }
        /// <summary>
        /// Button that opens the AddPerson(registration) window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string who = whoCombo.Text;
            AddPerson addPerson = new AddPerson(who, false);
        }
        /// <summary>
        /// Button to open the Login window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.ShowDialog();
        }
        /// <summary>
        /// When main window is closed application will shut down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Method that can populate lists with a few entries
        /// </summary>
        private void PopulateLists()
        {
            d.StaffTypes.Add("Visitor");
            d.StaffTypes.Add("Manager");
            d.StaffTypes.Add("Researcher");
            d.Zones.Add("Hot");
            d.Zones.Add("Habitable");
            d.Zones.Add("Cold");
            d.PlanetTypes.Add("Rocky Planet");
            d.PlanetTypes.Add("Super-Earth");
            d.PlanetTypes.Add("Mini-Neptune");
            d.PlanetTypes.Add("Ice Giant");
            d.PlanetTypes.Add("Gas Giant");
            if (d.Stars.Count == 0)
            {
                StarSystem sS1 = new StarSystem("Rigel", 12400, 6800);
                StarSystem sS2 = new StarSystem("Betelguese", 2400, 440);
                if (d.Planets.Count == 0)
                {
                    Planet p = new Planet(sS1.Name, "Akrea", "Rocky Planet", "Habitable");
                    Planet p1 = new Planet(sS2.Name, "Poseidos", "Gas Giant", "Cold");
                }
            }

        }
        /// <summary>
        /// An attempt to save information stored in database
        /// I suspect the Secure String saved in the dictionary is causing issues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Space exploration.dat", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, d);

                stream.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
    }
}
