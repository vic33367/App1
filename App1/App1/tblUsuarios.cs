using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace App1
{
    public class tblUsuarios
    {
        string id;
        string contraseña;
        string nombre;
        string paterno;
        string materno;
        string correo;
        string tipo;
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(PropertyName = "nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [JsonProperty(PropertyName = "ape_pat")]
        public string Paterno
        {
            get { return paterno; }
            set { paterno = value; }
        }
        [JsonProperty(PropertyName = "ape_mat")]
        public string Materno
        {
            get { return materno; }
            set { materno = value; }
        }
        [JsonProperty(PropertyName = "tipo")]
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        [JsonProperty(PropertyName = "correo")]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        [JsonProperty(PropertyName = "contrasena")]
        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        [Version]
        public string Version { get; set; }
    }
}
