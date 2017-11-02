using System.Collections.Generic;
using System;

namespace weddingPlanner.Models
{
    public class Weddings
    {
        public int weddingsId {get; set;}
        public string newlywedOne {get; set;}
        public string newlywedTwo {get; set;}
        public DateTime date {get; set;}
        public string address {get; set;}
        public int usersId {get; set;}
        public Users creator {get; set;}
        public List<Attending> guests {get; set;}

        public Weddings()
        {
            guests = new List<Attending>();
        }
    }
}