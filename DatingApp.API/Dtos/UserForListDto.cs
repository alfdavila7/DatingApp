using System;

namespace DatingApp.API.Dtos
{
    public class UserForListDto
    {
        // AutoMapper by default it will linkt together the classes named equally. We need to configure those which arent named equally.
        public int Id {get; set;}
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }
}