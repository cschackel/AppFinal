using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddJournalEntryPage : ContentPage
    {
        public AddJournalEntryPage()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            var newEntry = (StargazingJournalEntry)BindingContext;
            //await DisplayAlert("ID", ""+newEntry.JournalID, "OK");
            await App.Database.SaveItemAsync(newEntry);
            await Navigation.PopAsync();
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var entry = (StargazingJournalEntry)BindingContext;
            await App.Database.DeleteItemAsync(entry);
            await Navigation.PopAsync();
        }

        async private void Button_Clicked_2(object sender, EventArgs e)
        {
            App.Database.DeleteAllEntries();
            await Navigation.PopAsync();
        }
    }
}