using System;

namespace DatingApp.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        // We add this parameters so that entity framework creates a cascade delete when the user is deleted.
        public User User { get; set; } 
        public int UserId { get; set; }
    }
}