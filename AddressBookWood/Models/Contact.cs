
using System.ComponentModel.DataAnnotations;

namespace AddressBookWood.Models
{    public class Contact
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(64, ErrorMessage = "Contacts name must be less than 64 characters.")]
        public string Name { get; set; }
        
        [Phone]
        public string Phone { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(1024, ErrorMessage = "Note must be less than 1024 characters.")]
        public string Note { get; set; }

        public string Slug => Name?.Replace(' ', '-').ToLower();
    }
}