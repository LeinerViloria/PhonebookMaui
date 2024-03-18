using Phonebook.Models;

namespace Phonebook
{
    public partial class App : Application
    {
        public static List<ContactDTO> Contacts = new ()
        {
            new(){ Name = "Aaron", Occupation="Ing", Address="a@g.com" },
            new(){ Name = "Luz", Occupation="Ing", Address="b@g.com" }
        };
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
