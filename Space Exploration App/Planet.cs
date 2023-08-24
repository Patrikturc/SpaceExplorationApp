using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Exploration_App
{
    /// <summary>
    /// Planet class can set information about planet and add it to database
    /// </summary>
    public class Planet
    {
        /// <summary>
        /// instance of Database
        /// </summary>
        private Database d = Database.Instance;
        /// <summary>
        /// stores a name of stars to which this planet will be assigned to
        /// </summary>
        private string starName;
        /// <summary>
        /// Read-only property of name of star to which this planet will be assigned to
        /// </summary>
        public string StarName
        {
            get
            {
                return starName;
            }
        }
        /// <summary>
        /// Stores Name of the planet
        /// </summary>
        private string name;
        /// <summary>
        /// Stores type of the planet
        /// </summary>
        private string type;
        /// <summary>
        /// Stores zone in which the planet orbits
        /// </summary>
        private string zone;
        /// <summary>
        /// Read and Write property of the Zone stored
        /// </summary>
        public string Zone
        {
            get
            {
                return zone;
            }
            set
            {
                zone = value;
            }
        }
        /// <summary>
        /// Constructor of planet, assigns information about planet and adds it to the list of planets inside the database
        /// </summary>
        /// <param name="sN">Star name the planet is assigned to</param>
        /// <param name="n">Name of the planet</param>
        /// <param name="t">Type of the planet</param>
        /// <param name="z">Zone where the planet orbits</param>
        public Planet(string sN, string n, string t, string z)
        {
            starName = sN;
            name = n;
            type = t;
            zone = z;
            d.Planets.Add(this);
        }
        /// <summary>
        /// string representation of the specific planet object
        /// </summary>
        /// <returns>string representation of the specific planet object</returns>
        public override string ToString()
        {
            string strout = "Name : " + name;
            strout = strout + "\tType : " + type;
            strout = strout + "\tZone : " + zone + "\n_________________";
            return strout;
        }
    }
}
