using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Space_Exploration_App
{
    /// <summary>
    /// Database class, stores all lists and dictionaries of Space Exploration Application
    /// </summary>
    [Serializable]
    public class Database
    {
        /// <summary>
        /// Instance of the class Database
        /// </summary>
        private static Database database;
        /// <summary>
        /// Property that creates at first and then reads the Instance of the database class
        /// </summary>
        public static Database Instance
        {
            get
            {
                if (database == null)
                    database = new Database();
                return database;
            }
        }
        /// <summary>
        /// Stores zones in which the planet can be orbiting
        /// </summary>
        private static List<string> zones;
        /// <summary>
        /// Property that reads possible planet zones stored within the zones list
        /// </summary>
        public List<string> Zones
        {
            get
            {
                return zones;
            }
        }
        /// <summary>
        /// Stores types of planets in the universe
        /// </summary>
        private static List<string> planetTypes;
        /// <summary>
        /// Property that reads possible planet types stored within the planetTypes list
        /// </summary>
        public List<string> PlanetTypes
        {
            get
            {
                return planetTypes;
            }
        }
        /// <summary>
        /// Stores types of members in the database
        /// </summary>
        private static List<string> staffTypes;
        /// <summary>
        /// Property that reads possible Staff types within the staffTypes list
        /// </summary>
        public List<string> StaffTypes
        {
            get
            {
                return staffTypes;
            }
        }
        /// <summary>
        /// Stores all members that are currently registered
        /// </summary>
        private static List<People> members;
        /// <summary>
        /// Property that reads all registered members within members list
        /// </summary>
        public List<People> Members
        {
            get
            {
                return members;
            }
        }
        /// <summary>
        /// Stores login information about registered members login combination
        /// </summary>
        private static Dictionary<string, SecureString> log;
        /// <summary>
        /// Property used to compare login combination of registered members
        /// </summary>
        public Dictionary<string, SecureString> Log
        {
            get
            {
                return log;
            }

        }
        /// <summary>
        /// Stores all stars discovered
        /// </summary>
        private  List<StarSystem> stars;
        /// <summary>
        /// Property that reads or writes stars discovered inside the stars list
        /// </summary>
        public  List<StarSystem> Stars
        {
            get
            {
                return stars;
            }
            set
            {
                stars = value;
            }
        }
        /// <summary>
        /// List solely used for displaying a simple version of Stars string within combo boxes
        /// </summary>
        private static List<string> starS;
        /// <summary>
        /// Property that reads a simple version of star string - useful for combo boxes
        /// </summary>
        public List<string> StarS
        {
            get
            {
                return starS;
            }
            set
            {
                starS = value;
            }
            
        }
        /// <summary>
        /// Stores planets discovered
        /// </summary>
        private static List<Planet> planets;
        /// <summary>
        /// Reads all discovered planets of the planets list
        /// </summary>
        public List<Planet> Planets
        {
            get
            {
                return planets;
            }
            set
            {
                planets = value;
            }
        }
        /// <summary>
        /// Database constructor initializes all lists the application will use
        /// </summary>
        public Database()
        {
            staffTypes = new List<string>();
            members = new List<People>();
            log = new Dictionary<string, SecureString>();
            stars = new List<StarSystem>();
            planets = new List<Planet>();
            starS = new List<string>();
            zones = new List<string>();
            planetTypes = new List<string>();
        }
        /// <summary>
        /// Display method iterating through the list containing all planets discovered
        /// </summary>
        /// <returns>All discovered Planets as a string</returns>
        public string DisplayPlanets()
        {
            string pStr = "";
            foreach(Planet p in Planets)
            {
                pStr = pStr + p.ToString() + "\n";
            }
            return pStr;
        }
        /// <summary>
        /// Display method iterating through the list of all discovered stars and their assigned planets
        /// </summary>
        /// <returns>All discovered stars and their planets as a string</returns>
        public string DisplayStars()
        {
            string sSstr = "";
            foreach (StarSystem s in Stars) 
            {
                sSstr = sSstr + s.ToString();
            }
            return sSstr;
        }
        public string DisplayMembers()
        {
            string mStr = "";
            foreach (People peop in Members)
            {
                mStr = mStr + peop.ToString();
                mStr = mStr + "\n";
            }
            return mStr;
        }
        
    }
}
