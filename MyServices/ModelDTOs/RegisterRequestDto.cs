using System;

namespace MyServices.ModelDTOs
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string Answer { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int GenderId { get; set; }
    }
}