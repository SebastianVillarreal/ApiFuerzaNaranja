using System;
namespace marcatel_api.Models
{
    public class AuthInfo
    {
        

            public string Username { get; set; }
            public string IdUsername { get; set; }
            public string Userpassword { get; set; }
            public int caja {get; set;}


    }

    public class DatosHuellaModel
    {
        public int Id {get; set;}
        public int IdUsuario {get; set;}
        public decimal Descuento {get; set;}
        public string NombreCompleto {get; set;}
    }
}
