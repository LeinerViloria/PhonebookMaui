using DevExpress.Maui.Controls;
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

    public void OnEditPhoto(object sender, EventArgs e)
	{
        bottomSheet.State = BottomSheetState.HalfExpanded;
    }
}