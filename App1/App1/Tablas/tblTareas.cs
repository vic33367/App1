using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;

namespace App1
{
    public class tblTareas
    {
        string id;
        string tarea;
        string descripcion;
        string area;
        bool delete;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "tarea")]
        public string Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }

        [JsonProperty(PropertyName = "deleted")]
        public bool Delete
        {
            get { return delete; }
            set { delete = value; }
        }

        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
      
        [Version]
        public string Version { get; set; }

    }
}
