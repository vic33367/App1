using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;

namespace App1
{
    public class tblAsignarTareas
    {
        string id;
        string tarea;
        string asignado;
        string prioridad;
        string accion;
        DateTime fechaAsig;
        DateTime fechaTerm;
        string estatus;
        

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
        [JsonProperty(PropertyName = "prioridad")]
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        [JsonProperty(PropertyName = "accion")]
        public string Accion
        {
            get { return accion; }
            set { accion = value; }
        }
        [JsonProperty(PropertyName = "asignado")]
        public string Asignado
        {
            get { return asignado; }
            set { asignado = value; }
        }
        [JsonProperty(PropertyName = "fecha_asignacion")]
        public DateTime FechaTerm
        {
            get { return fechaTerm; }
            set { fechaTerm = value; }
        }

        [JsonProperty(PropertyName = "fecha_termino")]
        public DateTime FechaAsig
        {
            get { return fechaAsig; }
            set { fechaAsig = value; }
        }
        [JsonProperty(PropertyName = "estatus")]
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }
        [Version]
        public string Version { get; set; }

    }
}
