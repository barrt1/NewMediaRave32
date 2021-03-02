using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
/*
 Note: Most of our code comes from a tutorial put together by YouTube creator, Bert Bosch. --K


Citation: APA format 
Bosch, B. (Creator). (2017, December 31). Xamarin tutorials [Video playlist]. Retrieved February 26, 2021, from
https://www.youtube.com/playlist?list=PLV916idiqLvcKS1JY3S3jHWx9ELGJ1cJB

 */

namespace NewMediaRave.Data
{
    public interface InternetConnection
    {
        bool IsConnected { get; }
        void CheckConnection();

    }
}
