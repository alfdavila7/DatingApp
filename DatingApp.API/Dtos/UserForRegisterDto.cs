using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    //DTO (Data Transfer Objects) - Map the main models int simpler objects displayed at the view 
    public class UserForRegisterDto
    {
        [Required]//Data anotations to validate
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")] 
        //This is made posible because of the ApiController setted in the AuthController.cs
        public string Password { get; set; }
    }
}