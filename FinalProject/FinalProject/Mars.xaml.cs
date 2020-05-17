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
    public partial class Mars : ContentPage
    {
        public Mars()
        {
            InitializeComponent();
            targetDatePicker.MinimumDate = new DateTime(2012, 7, 8);
            targetDatePicker.MaximumDate = DateTime.Now;
            targetDatePicker.Date = new DateTime(DateTime.Now.Year,1,1);
        }

        private async void OnListGet(object sender, EventArgs e)
        {
            DateTime targetDate = targetDatePicker.Date;

            String dateString = targetDate.ToString("yyyy-MM-dd");

            var response = await App.restService.getPhotoListForDay(dateString);

            int count = response.Count;

            //await DisplayAlert("Results", "Count is " + count, "OK");

            //imagePane.Source = new Uri(response[0].URL);

            PicList.ItemsSource = (List<APIImage>)response;
        }

        private void PicList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            APIImage image = e.SelectedItem as APIImage;
            Navigation.PushAsync(new PicImagePage(image.URL));
        }
    }
}