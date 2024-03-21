using DevExpress.Maui.Controls;
using DevExpress.Maui.Core;
using Phonebook.Models;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace Phonebook.Templates;

public partial class ContactDetail : ContentPage
{
    public DetailFormViewModel ViewModel => (DetailFormViewModel)BindingContext;

    public ContactDTO Contact => (ContactDTO)ViewModel.Item;
    
    public ContactDetail()
	{
		InitializeComponent();
	}

    public void OnEditPhoto(object sender, EventArgs e)
	{
        bottomSheet.State = BottomSheetState.HalfExpanded;
    }

    public void Call(object sender, EventArgs e)
	{

    }

    public void Edit(object sender, EventArgs e)
	{
	editBottomSheet.State = BottomSheetState.HalfExpanded;
    }

    public void Delete(object sender, EventArgs e)
	{
	var Result = App.Contacts.First(x => x.Id == Contact.Id);
 	App.Contacts.Remove(Result);

  	_ = Navigation.PopAsync();
    }
    

}
