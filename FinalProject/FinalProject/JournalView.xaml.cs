using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class JournalView : ContentPage
    {
        public JournalView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            JournalList.ItemsSource = await App.Database.GetItemsAsync();
        }

        async private void OnJournalItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddJournalEntryPage
                {
                    BindingContext = e.SelectedItem as StargazingJournalEntry
                });
            }
        }

        async private void AddJournalEntryButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddJournalEntryPage
            {
                BindingContext = new StargazingJournalEntry()
            });

        }
    }
}