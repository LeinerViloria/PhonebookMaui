using Microsoft.Maui.Controls;

namespace Phonebook.Models
{
    public class ContactDTO
    {
        public string Id => $"{Guid.NewGuid()}";
        public string Name { get; set; } = null!;
        public dynamic Image => ImageSource is null ? DefaultImage : ImageSource;
        public string? Email { get; set; }
        public string? Occupation { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; } = null!;

        private string DefaultImage => "contact_default.png";
        public ImageSource? ImageSource {get; set;}
        
    }


}

