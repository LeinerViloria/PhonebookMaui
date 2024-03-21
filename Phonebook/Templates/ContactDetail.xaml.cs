using DevExpress.Maui.Controls;
using DevExpress.Maui.Core;
using Phonebook.Models;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using DevExpress.Maui.Editors;

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
        if(string.IsNullOrEmpty(Contact.PhoneNumber))
        {
            _ = Phonebook.Utils.Utils.ShowToast("El contacto no tiene un telefono al cual llamar");
            return;
        }
        Phonebook.Utils.Utils.Call(Contact.PhoneNumber);
    }

    public void SendMessage(object sender, EventArgs e)
	{
        if(string.IsNullOrEmpty(Contact.PhoneNumber))
        {
            _ = Phonebook.Utils.Utils.ShowToast("El contacto no tiene un telefono al cual enviar un mensaje");
            return;
        }
        _ = Phonebook.Utils.Utils.SendMessage(Contact.PhoneNumber);
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

    private void UpdateContactPhoto()
    {
        //App.Contacts.First(x => x.Id == Contact.Id).ImageSource = ((ContactDTO) ViewModel.Item).Image;
    }

    public void TakePicture(object sender, EventArgs e)
    {
        _ = TaskPictureAsync();
    }

    public async Task TaskPictureAsync()
    {
        var photo = await MediaPicker.CapturePhotoAsync();

        if(photo is null)
            return;
        
        var memoriaStream = await photo.OpenReadAsync();

        var Image = ImageSource.FromStream(() => memoriaStream);
        profilePhoto.Source = Image;
        //((ContactDTO) ViewModel.Item).ImageSource = Image;

        UpdateContactPhoto();

        bottomSheet.State = BottomSheetState.Hidden;
    }

    public void CloseUpdate(object sender, EventArgs e)
    {
        editBottomSheet.State = BottomSheetState.Hidden;
    }

    public void UploadPhoto(object sender, EventArgs e)
    {
        _ = UploadPhotoAsync();
    }

    private async Task UploadPhotoAsync()
    {
        var photo = await MediaPicker.PickPhotoAsync();

        if(photo is null)
            return;

        var memoriaStream = await photo.OpenReadAsync();

        var Image = ImageSource.FromStream(() => memoriaStream);
        profilePhoto.Source = Image;
        //((ContactDTO) ViewModel.Item).ImageSource = Image;

        UpdateContactPhoto();

        bottomSheet.State = BottomSheetState.Hidden;
    }

    private void ValidateRequired(TextEdit textEdit)
    {
        textEdit.HasError = false;

        if (!string.IsNullOrWhiteSpace(textEdit.Text))
            return;

        textEdit.ErrorText = $"{textEdit.LabelText} es requerido";
        textEdit.HasError = true;
    }

    private bool ValidateRequired(params TextEdit[] values)
    {
        for (int i = 0; i < values.Length; i++)
            ValidateRequired(values[i]);

        return values.ToList().TrueForAll(x => !x.HasError);
    }

    public void OnEdit(object sender, EventArgs e)
    {
        var Continue = ValidateRequired(txtName, txtOccupation, txtPhone, txtAddress, txtEmail);

        if (!Continue)
                return;

        ((ContactDTO) ViewModel.Item).Name = txtName.Text;
        ((ContactDTO) ViewModel.Item).Occupation = txtOccupation.Text;
        ((ContactDTO) ViewModel.Item).PhoneNumber = txtPhone.Text;
        ((ContactDTO) ViewModel.Item).Address = txtAddress.Text;
        ((ContactDTO) ViewModel.Item).Email = txtEmail.Text;

        editBottomSheet.State = BottomSheetState.Hidden;

        txtName.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtOccupation.Text = string.Empty;
        txtPhone.Text = string.Empty;

        _ = Phonebook.Utils.Utils.ShowToast("Contacto actualizado");
    }
    

}
