using System.ComponentModel.DataAnnotations;

namespace WasteDisposalManagement.Models
{
    public class UpdateUser
    {
        [Display(Name = "First Name"), StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 0)]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name"), StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 0)]
        public string? LastName { get; set; }

        [Required, MaxLength(11), MinLength(11)]
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }


        [Required, Display(Name = "Address"), StringLength(400, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 0)]
        public string? Address { get; set; }

        [Display(Name = "City"), StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 0)]
        public string? City { get; set; }

        [Display(Name = "State"), StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 0)]
        public string? State { get; set; }

        public byte[]? ProfilePicture { get; set; }
    }
}
