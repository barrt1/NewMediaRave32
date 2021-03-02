using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
/*
 Note: Most of our code comes from a tutorial put together by YouTube creator, Bert Bosch. --K

Citation: APA format 
Bosch, B. (Creator). (2017, December 31). Xamarin tutorials [Video playlist]. Retrieved February 26, 2021, from
https://www.youtube.com/playlist?list=PLV916idiqLvcKS1JY3S3jHWx9ELGJ1cJB
 */
namespace NewMediaRave.Models
{
    public class Constants
    {
        public static bool IsDev = true;

        public static Color BackdropColor = Color.White; //Exactly what it says. White. --K

        public static Color ButtonColor = Color.FromHex("#23cad0"); //Bright teal. --K

        public static Color MainTextColor = Color.FromHex("#5132b1"); //Dark, blue-violet. --K

        //----Login------ 
        public static string LoginUrl = "https://test.com/api/Auth/Login";

        public static string NoInternetText = "No Internet, please reconnect";
   
    
    }
}
