using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            //var newEntry = (StargazingJournalEntry)BindingContext;

            
        }

        protected override async void OnAppearing()
        {
            var newEntry = (StargazingJournalEntry)BindingContext;
            if (newEntry.JournalID == 0)
            {
                try
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if (location != null)
                    {
                        
                        latEntry.Text = location.Latitude.ToString();
                        longEntry.Text = location.Longitude.ToString();
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    // Handle not enabled on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to get location
                }
            }

            if (newEntry.JournalID == 0)
            {
                dateEntry.MaximumDate = DateTime.Today;

                dateEntry.Date = DateTime.Now;
            }

            
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            var newEntry = (StargazingJournalEntry)BindingContext;
            //await DisplayAlert("ID", ""+newEntry.JournalID + " " + newEntry.StellarObject, "OK");

            String stelarOb = newEntry.StellarObject;


            if (stelarOb==null)
            {
                Vibration.Vibrate();
                await DisplayAlert("Insufficient Data!", "Please enter a Stellar Object", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Lat: " + newEntry.Lat + " - Long: " + newEntry.Long, "OK");
                await DisplayAlert("Alert", "Lat: " + latEntry.Text + " - Long: " + longEntry.Text, "OK");

                String tempLatString = latEntry.Text;

                String tempLongString = longEntry.Text;


                if (tempLatString == null || tempLatString == "" ||tempLatString.Equals(""))
                {
                    newEntry.Lat = null;
                }
                else
                {
                    double tempLat = -1;
                    Double.TryParse(latEntry.Text, out tempLat);
                    newEntry.Lat = tempLat;
                }

                if (tempLongString == null || tempLongString.Equals("")|| tempLongString == "")
                {
                    newEntry.Long = null;
                }
                else
                {
                    double tempLong = -1;
                    Double.TryParse(longEntry.Text, out tempLong);
                    newEntry.Long = tempLong;
                }


                

                //await DisplayAlert("Alert","Lat: " + tempLat + " - Long: " + tempLong,"OK");


                //await DisplayAlert("Alert", "Lat: " + newEntry.Lat + " - Long: " + newEntry.Long, "OK");
                await App.Database.SaveItemAsync(newEntry);
                await Navigation.PopAsync();
            }
            
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