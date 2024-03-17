using DevExpress.Maui.Controls;
using DevExpress.Maui.Editors;
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
            bottomSheet.State = BottomSheetState.HalfExpanded;
        }

        public void OnCancel(object sender, EventArgs e)
        {
            bottomSheet.State = BottomSheetState.Hidden;
        }

        private void ValidateRequired(TextEdit textEdit)
        {
            textEdit.HasError = false;

            if(!string.IsNullOrWhiteSpace(textEdit.Text))
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

        public void Save(object sender, EventArgs e)
        {
            var Continue = ValidateRequired(txtName, txtOccupation, txtPhone, txtAddress, txtEmail);

            if (!Continue)
                return;

            var NewContact = new ContactDTO()
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                Occupation = txtOccupation.Text,
                PhoneNumber = txtPhone.Text
            };

            Contacts.Add(NewContact);
            bottomSheet.State = BottomSheetState.Hidden;
        }
    }

}
