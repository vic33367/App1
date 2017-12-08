using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;

namespace App1
{
    public class tblareas
    {
        string id;
        string area;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "area")]
        public string Area
        {
            get { return area; }
            set { area = value; }
        }
        [Version]
        public string Version { get; set; }

    }
}
