using NewMediaRave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewMediaRave.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            Init();       
        }
        void Init()
        {
            BackgroundColor = Constants.BackdropColor;
            App.StartCheckIfInternet(lbl_NoInternet, this);
        }
       async void screen1selected(object sender, EventArgs e)
        {
            //Navigating to first screen now ! also using Dashboard.xaml.cs
            await Navigation.PushAsync(new InformationScreen1st());
        }
    }
}