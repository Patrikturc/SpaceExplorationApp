using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Exploration_App
{
    /// <summary>
    /// Address class
    /// simple address with street town and postcode
    /// no protection coded for attributes
    /// </summary>
    [Serializable]
    public class Address
    {
        /// <summary>
        /// street
        /// </summary>
        private string street;
        /// <summary>
        /// town
        /// </summary>
        private string town;
        /// <summary>
        /// postcode
        /// </summary>
        private string postcode;

        /// <summary>
        /// Street
        /// read/write property for street
        /// set method has no protection
        /// </summary>
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }

        /// <summary>
        /// Town
        /// read/write property for town
        /// set method has no protection 
        /// </summary>
        public string Town
        {
            get 
            { 
                return town; 
            }
            set 
            { 
                town = value; 
            }
        }

        /// <summary>
        /// Postcode
        /// read/write property for postcode
        /// set method has no protection 
        /// </summary>
        public string Postcode
        {
            get 
            { 
                return postcode; 
            }
            set 
            { 
                postcode = value; 
            }
        }

        /// <summary>
        /// overriden ToString method
        /// </summary>
        /// <returns>string representation of address</returns>
        public override string ToString()
        {
            string strout;
            strout = Street + "\n" + Town + "\n" + Postcode + "\n";
            return strout;
        }

    }
}

