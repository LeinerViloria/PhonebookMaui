using DevExpress.Maui.Core;
using Phonebook.Models;

namespace Phonebook.Templates;

public partial class ContactDetail : ContentPage
{
	public DetailFormViewModel ViewModel => (DetailFormViewModel)BindingContext;

	public ContactDTO Contact => (ContactDTO) ViewModel.Item;


    public ContactDetail()
	{
		InitializeComponent();
	}
}