
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WasteDisposalManagement.Models
{
    public class User:IdentityUser
    {

        [Required, MaxLength(50)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = null!;

        public byte[]? ProfilePicture { get; set; }

       
        [Required, DataType(DataType.MultilineText)]
        public string Address { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string State { get; set; } = null!;

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public virtual ICollection<Card> Card { get; } = new List<Card>();

        public virtual ICollection<FirstTimeOrder> FirstTimeOrder { get;} = new List<FirstTimeOrder>();

        public virtual ICollection<Order> Order { get; } = new List<Order>();
    }
}
