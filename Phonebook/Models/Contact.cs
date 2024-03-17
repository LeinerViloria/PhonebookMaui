
namespace Phonebook.Models
{
    public class ContactDTO
    {
        public string Id => $"{Guid.NewGuid()}";
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string? Email { get; set; }
        public string? Occupation { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; } = null!;
    }
}
