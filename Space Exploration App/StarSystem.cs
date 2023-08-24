using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Exploration_App
{
    /// <summary>
    /// Star system class can create a new star system and assign it some attributes
    /// </summary>
    public class StarSystem
    {
        /// <summary>
        /// instance of database
        /// </summary>
        private Database d = Database.Instance;
        /// <summary>
        /// stores name of the star
        /// </summary>
        private string name;
        /// <summary>
        /// Read-only property of Stars name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
        /// <summary>
        /// stores temperature of new star in Kelvin
        /// </summary>
        private int temperature;
        /// <summary>
        /// stors distance from earth of a new star in light years
        /// </summary>
        private int distance;
        /// <summary>
        /// New star system constructor assisngs star variables and adds it to appropriate lists in database
        /// </summary>
        /// <param name="n"></param>
        /// <param name="t"></param>
        /// <param name="di"></param>
        public StarSystem(string n, int t, int di)
        {
            name = n;
            temperature = t;
            distance = di;
            d.Stars.Add(this);
            AddStar(n);
        }
        /// <summary>
        /// Adds a simple version of star string into a string list
        /// </summary>
        /// <param name="n"></param>
        private void AddStar(string n)
        {
            d.StarS.Add(n);
        }
        /// <summary>
        /// A string representation of star object
        /// </summary>
        /// <returns>string representation of star object</returns>
        public override string ToString()
        {
            string strout = "\nStar name: " + name;
            strout = strout + "\nTemperature of star: " + temperature.ToString() + " Kelvin";
            strout = strout + "\nDistance from Earth: " + distance.ToString() +  " Light Years";
            strout = strout + "\n\nPlanets in orbit\n" + FindPlanets() + "\n";
            return strout;
        }
        /// <summary>
        /// Allows star's to string method to display all planets orbiting it with the star system
        /// </summary>
        /// <returns>All planets orbiting the specific star</returns>
        private string FindPlanets()
        {
            string planets = "";
            foreach(Planet p in d.Planets)
            {
                if(p.StarName == name)
                {
                    planets = planets + p.ToString() + "\n";
                }
            }
            return planets;
        }
    }
}
