using Space_Exploration_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Space_Exploration_App
{
    /// <summary>
    /// Superclass People allows AddPerson window to create new members of the application
    /// it's subtypes : Visitor, Researcher and Member are all types of members that
    /// application supports 
    /// </summary>
    [Serializable]
    public abstract class People
    {
        /// <summary>
        /// initializes Address class
        /// </summary>
        private Address address = new Address();
        /// <summary>
        /// instance of Database
        /// </summary>
        protected Database d = Database.Instance;
        /// <summary>
        /// General temporary storage of Members ID
        /// </summary>
        private string iDg;
        /// <summary>
        /// stores members first name
        /// </summary>
        protected string fName;
        /// <summary>
        /// First name property, only able to read the first name of a member
        /// </summary>
        public string FName
        {
            get
            {
                return fName;
            }
        }
        /// <summary>
        /// stores members last name
        /// </summary>
        protected string lName;
        /// <summary>
        /// Last name property, can read and modify members last name
        /// </summary>
        public string LName
        {
            get
            {
                return lName;
            }
            set
            {
                lName = value;
            }
        }
        /// <summary>
        /// general ID property, can read and modify ID, this property is used when users login details 
        /// are deleted from the dictionary
        /// </summary>
        public string IDg
        {
            get
            {
                return iDg;
            }
            set
            {
                iDg = value;
            }
        }
        
        /// <summary>
        /// Address property can read address of a member
        /// </summary>
        public Address Address
        {
            get
            {
                return address;
            }
        }
        /// <summary>
        /// sets Members address
        /// </summary>
        /// <param name="town">Please enter town where member stays</param>
        /// <param name="street">Please enter street where member stays</param>
        /// <param name="postcode">Please enter postcode of the members street</param>
        public void setAddress(string town, string street, string postcode)
        {
            address.Town = town;
            address.Street = street;
            address.Postcode = postcode;
        }
        /// <summary>
        /// Default constructor - Should be never used as app has protection against empty spaces
        /// it exists only in case of failure
        /// </summary>
        public People()
        {
            fName = "N/A";
            lName = "N/A";
            setAddress("N/A", "N/A", "N/A");
        }
        /// <summary>
        /// Login method that adds a new login combination into list
        /// </summary>
        /// <param name="id">enters members ID</param>
        /// <param name="pw">Sets Members Password</param>
        public void Login(string id, SecureString pw)
        {
            d.Log.Add(id, pw);
        }
        /// <summary>
        /// Method used to add member into the list of members
        /// </summary>
        /// <param name="p">Member to add</param>
        public void AddMember(People p)
        {
            d.Members.Add(p);
        }
        /// <summary>
        /// New member constructor takes in basic information about a user
        /// and sets name and last name
        /// </summary>
        /// <param name="fname">first name of new member</param>
        /// <param name="lname">last name of new member</param>
        /// <param name="Spw">Secure password of a new member</param>
        public People(string fname, string lname, SecureString Spw)
        {
            fName = fname;
            lName = lname;
        }
        /// <summary>
        /// New member constructor which sets more detailed information about the new member
        /// </summary>
        /// <param name="fname">first name of new member</param>
        /// <param name="lname">last name of new member</param>
        /// <param name="town">town of the new member</param>
        /// <param name="street">street of a new member</param>
        /// <param name="postcode">postcode of a new member</param>
        /// <param name="yob">year of birth of a new member</param>
        /// <param name="pw">Secure password of a new member</param>
        public People(string fname, string lname, string town, string street, string postcode, ushort yob, SecureString pw)
        {
            fName = fname;
            lName = lname;
            setAddress(town,street,postcode);
        }
    }

    /// <summary>
    /// Researcher Class a subclass of abstract class People
    /// it is capable of adding a new researcher to Members list
    /// Researchers have their unique UI
    /// </summary>
    public class Researcher : People
    {
        /// <summary>
        /// Id of a new researcher
        /// </summary>
        private string rId;
        /// <summary>
        /// topic the new researcher is focused on
        /// </summary>
        private string rTopic;
        /// <summary>
        /// Researchers year of birth
        /// </summary>
        private ushort yOb;
        /// <summary>
        /// read-only property of researchers ID
        /// </summary>
        public string RId
        {
            get
            {
                return rId;
            }
        }
        /// <summary>
        /// Researcher constructor sets all information about researcher and adds it to the list of members
        /// it also creates a unique login combination for the specific member
        /// </summary>
        /// <param name="fname">first name of new member</param>
        /// <param name="lname">last name of new member</param>
        /// <param name="town">town of the new member</param>
        /// <param name="street">street of a new member</param>
        /// <param name="postcode">postcode of a new member</param>
        /// <param name="yob">year of birth of a new member</param>
        /// <param name="researcherid">Id of the new researcher</param>
        /// <param name="researchtopic">sets topic the researcher is focused on</param>
        /// <param name="pw">A secure string password for this researcher</param>
        public Researcher(string fname, string lname, string town, string street, string postcode, ushort yob, int researcherid, string researchtopic, SecureString pw) : base(fname, lname, town, street, postcode, yob, pw)
        {
            IDg = "r" + researcherid;
            rId = "r" + researcherid;
            rTopic = researchtopic;
            yOb = yob;
            Login(rId, pw);
            AddMember(this);

        }
        /// <summary>
        /// A string representation of a specific researcher object
        /// </summary>
        /// <returns>This reseacher object string representation</returns>
        public override string ToString()
        {
            string str;
            str = string.Format("Researcher ID: {0},", rId);
            str = str + string.Format("\tLast name: {0}", lName);
            return str;
        }
    }
    /// <summary>
    /// Manager subclass of abstact class people
    /// it can add a new manager to database
    /// </summary>
    public class Manager : People
    {
        /// <summary>
        /// Manager ID
        /// </summary>
        private string mId;
        /// <summary>
        /// department id of manager
        /// </summary>
        private ushort depId;
        /// <summary>
        /// year of birth of manager
        /// </summary>
        private ushort yOb;
        /// <summary>
        /// Manager Constructor sets all information about the managerand adds it to list of members
        /// It also creates a unique and secure login for the manager
        /// </summary>
        /// <param name="fname">first name of new member</param>
        /// <param name="lname">last name of new member</param>
        /// <param name="town">town of the new member</param>
        /// <param name="street">street of a new member</param>
        /// <param name="postcode">postcode of a new member</param>
        /// <param name="yob">year of birth of a new member</param>
        /// <param name="managerId">Managers ID to set</param>
        /// <param name="depid">department id to set</param>
        /// <param name="pw">Secure password for this manager</param>
        public Manager(string fname, string lname, string town, string street, string postcode, ushort yob, int managerId, ushort depid, SecureString pw) : base(fname, lname, town, street, postcode, yob, pw)
        {
            IDg = "m" + managerId;
            mId = "m" + managerId;
            depId = depid;
            yOb = yob;
            Login(mId, pw);
            AddMember(this);
        }
        /// <summary>
        /// A string representation of this Manager object
        /// </summary>
        /// <returns>this manager class string representation</returns>
        public override string ToString()
        {
            string str;
            str = string.Format("Manager ID: {0},", mId);
            str = str + string.Format("\tLast name: {0}", lName);
            return str;
        }
    }
    /// <summary>
    /// Visitor is a subclass of abstact class people
    /// it can add a new visitor to the database
    /// </summary>
    public class Visitor : People
    {
        /// <summary>
        /// Visitors ID
        /// </summary>
        public string VId { get; }
        /// <summary>
        /// Constructor for a Visitor type member, it sets all information requried about the visitor and adds it to the members list
        /// it also creates a secure login combination stored in login dictionary
        /// </summary>
        /// <param name="fname">first name of new member</param>
        /// <param name="lname">last name of new member</param>
        /// <param name="id">Sets Visitors login id</param>
        /// <param name="Spw">Sets Visitors secure Password</param>
        public Visitor(string fname, string lname, int id, SecureString Spw) : base(fname, lname, Spw)
        {
            IDg = "v" + id;
            VId = "v" + id;
            Login(VId, Spw);
            AddMember(this);
        }
        /// <summary>
        /// To string representation of this Visitor object
        /// </summary>
        /// <returns>String representation of this Visitor object</returns>
        public override string ToString()
        {
            string str;
            str = string.Format("Visitor ID: {0},", VId);
            str = str + string.Format("\t\tLast name: {0}", lName);
            return str;
        }
        
    }
}
