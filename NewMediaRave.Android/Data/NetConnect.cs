using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net; //added for CheckConnection() to work. --K
using NewMediaRave.Data; //must be used to implement interface. --K
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewMediaRave.Droid.Data;

/*
 Note: Most of our code comes from a tutorial put together by YouTube creator, Bert Bosch. --K

Citation: APA format 
Bosch, B. (Creator). (2017, December 31). Xamarin tutorials [Video playlist]. Retrieved February 26, 2021, from
https://www.youtube.com/playlist?list=PLV916idiqLvcKS1JY3S3jHWx9ELGJ1cJB

 */

[assembly: Xamarin.Forms.Dependency(typeof(NetConnect))]

namespace NewMediaRave.Droid.Data
{
    public class NetConnect : InternetConnection
    {
        public bool IsConnected
        {
            get; set;
        }

       
        public void CheckConnection()
        {
            var ConnectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = ConnectivityManager.ActiveNetworkInfo;
            if (ActiveNetworkInfo != null && ActiveNetworkInfo.IsConnectedOrConnecting)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }
        }
    }
}