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
    public partial class PicImagePage : ContentPage
    {
        public PicImagePage(String url)
        {
            InitializeComponent();
            imagePanel.Source = new Uri(url);
        }

        private void Back_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}