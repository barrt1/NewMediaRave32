using NewMediaRave.Data;
using NewMediaRave.Models;

using NewMediaRave.Views;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using LocalDatabaseTutorial;


/*
 Note: Most of our code comes from a tutorial put together by YouTube creator, Bert Bosch. --K

Citation: APA format 
Bosch, B. (Creator). (2017, December 31). Xamarin tutorials [Video playlist]. Retrieved February 26, 2021, from
https://www.youtube.com/playlist?list=PLV916idiqLvcKS1JY3S3jHWx9ELGJ1cJB

 */

namespace NewMediaRave
{
    public partial class App : Application
    {
        static RestService restService; //referencing RestService class for Rest API. --K
        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentpage;
        private static Timer timer;
        private static bool noInterShow;



        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }

        // ---internet connection----
        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentpage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    CheckIfInternetOverTime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);

            }

        }

        private static void CheckIfInternetOverTime()
        {
            var networkConnection = DependencyService.Get<InternetConnection>();
            networkConnection.CheckConnection();
            if (!networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (hasInternet)
                        {
                            if (!noInterShow)
                            {
                                hasInternet = false;
                                labelScreen.IsVisible = true;
                                await showDisplayAlert();
                            }
                        }
                    });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }
        public static bool CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<InternetConnection>();
            networkConnection.CheckConnection();
            return networkConnection.IsConnected;
        }
        public static async Task<bool> CheckIfInternetAlertAsync()
        {
            var networkConnection = DependencyService.Get<InternetConnection>();
            networkConnection.CheckConnection();
            return networkConnection.IsConnected;
            if (!networkConnection.IsConnected)
            {
                if(!noInterShow)
                {
                    await showDisplayAlert();
                }
                return false;
            }
            return true;
        }

        private static async Task showDisplayAlert()
        {
            noInterShow = false;
            await currentpage.DisplayAlert("Internet", "There is no Internet, Please reconnect", "oke");
            noInterShow = false;


        }
    }

    //-- Database stuff --//

        public partial class App : Application
        {
            static Database database;

            public static Database Database
            {
                get
                {
                    if (database == null)
                    {
                        database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                    }
                    return database;
                }
            }

            public App()
            {
                InitializeComponent();

                MainPage = new LoginPage();
            }

            protected override void OnStart()
            {
                // Handle when your app starts
            }

            protected override void OnSleep()
            {
                // Handle when your app sleeps
            }

            protected override void OnResume()
            {
                // Handle when your app resumes
            }
        }


}



