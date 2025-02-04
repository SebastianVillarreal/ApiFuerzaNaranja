using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;

namespace marcatel_api.Controllers
{
   
    [Route("api")]
    public class AdminController: ControllerBase
    {
        private readonly AdminService _adminService;
        private readonly ILogger<AdminController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        Encrypt enc = new Encrypt();

        public AdminController(AdminService adminservice, ILogger<AdminController> logger, IJwtAuthenticationService authService) {
            _adminService = adminservice;
            _logger = logger;
       
            _authService = authService;
        }



        [HttpPost("Cambiar")]
        public JsonResult UpdatePwd([FromBody] CategoriaModel categoria)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var articulo = _adminService.UpdatePWd(categoria.Descripcion, categoria.id);
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                objectResponse.response = new
                {
                    data = articulo
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("InsertCategoria")]
        public JsonResult InsertCategoria([FromBody] CategoriaModel categoria)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var articulo = _adminService.InsertCategoria(categoria);
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                objectResponse.response = new
                {
                    data = articulo
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }


        
        [HttpPost("GetUsuarios")]
        public JsonResult GetUsuarios()
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _adminService.GetUsuarios();
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [HttpPost("UpdateHuella")]
        public JsonResult UpdateHuella([FromBody] InsertHuellaModel huella)
        {

            var objectResponse = Helper.GetStructResponse();
            try
            {
                 _adminService.UpodateHuellaCajero( huella.Huella, huella.Id );
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información recuperada con exito";
                objectResponse.response = new
                {
                    data = true
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            return new JsonResult(objectResponse);
        }

        [HttpPost("InsertHuella")]
        public JsonResult InsertHuella([FromBody] InsertHuellaModel huella)
        {

            var objectResponse = Helper.GetStructResponse();
            try
            {
                 _adminService.InsertaHuellaCajero( huella.Huella, huella.Id );
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información recuperada con exito";
                objectResponse.response = new
                {
                    data = true
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            return new JsonResult(objectResponse);
        }

        [HttpPost("InsertPersona")]
        public JsonResult InsertPersona([FromBody] PersonaModel persona)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _adminService.InsertPersona(persona, 1);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            return new JsonResult(objectResponse);
        }

        
    }
}
