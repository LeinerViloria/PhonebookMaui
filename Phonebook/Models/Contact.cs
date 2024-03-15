
namespace Phonebook.Models
{
    public class ContactDTO
    {
        public string Id => $"{Guid.NewGuid()}";
        public string Name { get; set; }
        public string LastName {  get; set; }
        public string FullName => $"{Name} {LastName}";
        public string Image {  get; set; }
    }
}
