using System.Collections.Generic;

namespace weddingPlanner.Models
{
    public class Users
    {
        public int usersId {get; set;}
        public string firstName {get; set;}
        public string lastName {get; set;}
        public string email {get; set;}
        public string password {get; set;}

        public List<Weddings> weddings {get; set;}
        public List<Attending> attending {get; set;}

        public Users()
        {
            weddings = new List<Weddings>();
            attending = new List<Attending>();
        }
    }
}