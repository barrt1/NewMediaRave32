using NewMediaRave.Models;
using NewMediaRave.ViewModels;
using NewMediaRave.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
/*
 Note: Most of our code comes from a tutorial put together by YouTube creator, Bert Bosch. --K


Citation: APA format 
Bosch, B. (Creator). (2017, December 31). Xamarin tutorials [Video playlist]. Retrieved February 26, 2021, from
https://www.youtube.com/playlist?list=PLV916idiqLvcKS1JY3S3jHWx9ELGJ1cJB
 */

namespace NewMediaRave.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            StyleColors();
            this.BindingContext = new LoginViewModel();

        }


        void StyleColors() //references colors contained in the Constants class. --K
        {
            BackgroundColor = Constants.BackdropColor;
            Lbl_UserName.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            Btn_Signin.BackgroundColor = Constants.ButtonColor;

            App.StartCheckIfInternet(lbl_NoInternet, this);

      
        }

        async Task SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Success!", "Okay");
                var result = await App.RestService.Login(user);
                //dummy token 
                if (result != null)
                {
                    // login page to dashboard
                    await Navigation.PushAsync(new Dashboard());
                    if (Device.OS == TargetPlatform.Android)
                    {
                        Application.Current.MainPage = new NavigationPage(new Dashboard());
                    }
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                        await Navigation.PushModalAsync(new NavigationPage(new Dashboard()));
                    }
                }
            }
                else
            {
                DisplayAlert("Login", "Error: Please enter a username and password.", "Okay");
            }
        }

    }

}