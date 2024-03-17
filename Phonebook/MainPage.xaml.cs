using Phonebook.Models;
using System.Collections.ObjectModel;

namespace Phonebook
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ContactDTO> Contacts { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Contacts = new ObservableCollection<ContactDTO>(App.Contacts);

            BindingContext = this;
        }

        public void OnCreate(object sender, EventArgs e)
        {
            //...
        }
    }

}
