namespace weddingPlanner.Models
{
    public class Attending
    {
        public int attendingId {get; set;}
        public int usersId {get; set;}
        public Users user {get; set;}
        public int weddingsId {get; set;}
        public Weddings wedding {get; set;}
    }
}