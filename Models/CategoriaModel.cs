using System;
namespace marcatel_api.Models
{
    public class CategoriaModel
    {
        public int id {get; set;}
        public string Nombre {get; set;}
        public string Descripcion {get; set;}
        public int usuario {get; set;}
    }

    public class FormasRequestModel
    {
        public int Usuario {get; set;}
        public int Cliente {get; set;}
        public decimal Total {get; set;}
    }

    public class PersonaModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre {get; set;}
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Perfil { get; set; }
        public int IdSede { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreSede { get; set; }

    }

    public class InsertHuellaModel
    {
        public byte[] Huella {get; set;}
        public int IdCajero {get; set;}
        public int Id {get; set;}
    }
}