using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace otk
{
    public class UserItem
    {
        string id;
        string userName;
        string challengeData;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "userName")]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        [JsonProperty(PropertyName = "challengeData")]
        public string ChallengeData
        {
            get { return challengeData; }
            set { challengeData = value; }
        }
    }
}

