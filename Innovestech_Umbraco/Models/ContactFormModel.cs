using System.ComponentModel.DataAnnotations;

namespace TSPadel_Umbraco.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Address { get; set; }
        public string Phone_Number { get; set; }
        public string Contact_Message { get; set; }
    }
}