using Phonebook.Models;

namespace Phonebook
{
    public partial class App : Application
    {
        public static List<ContactDTO> Contacts = new ()
        {
            new(){ Name = "Aaron" },
            new(){ Name = "Luz" }
        };
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
