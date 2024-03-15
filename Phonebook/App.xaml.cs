using Phonebook.Models;

namespace Phonebook
{
    public partial class App : Application
    {
        public static List<ContactDTO> Contacts = new ()
        {
            new(){ Name = "Aaron", LastName = "Mendonza" },
            new(){ Name = "Luz", LastName = "García" }
        };
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
