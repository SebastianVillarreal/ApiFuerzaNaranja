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
    public class LoginController: ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly ILogger<LoginController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        Encrypt enc = new Encrypt();

        public LoginController(LoginService loginservice, ILogger<LoginController> logger, IJwtAuthenticationService authService) {
            _loginService = loginservice;
            _logger = logger;
       
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public JsonResult SignIn([FromBody] AuthInfo user)
        {
            
            ResponseLogin result = new ResponseLogin();
            result.Response = new ResponseBody();
            result.Response.data = new DataResponseLogin();
            result.Response.data.Usuario = new UsuarioModel();
          
                string cryptedPass = enc.GetSHA256(user.Userpassword);
           
            var loginResponse = _loginService.Login(user.Username, user.Userpassword);

         
           
                if (loginResponse.Id != 0 && loginResponse.Id != 999999 )
                {
                    result.StatusCode = (int)HttpStatusCode.OK;
                    result.Error = false;
                    result.Success = true;
                    result.Message = "Bienvenido";
                    result.Response.data.Usuario = loginResponse;
                    result.Response.data.Status = true;
                    result.Response.data.Mensaje = "Bienvenido";


                }
                else if(loginResponse.Id == 999999)
                {
                    result.StatusCode = 300;
                    result.Message = "Corte Pendiente";
                    result.Error = true;
                    result.Success = false;
                }
                else
                {
                    result.Error = true;
                    result.Success = false;
                    result.Message = "Usuario o contraseña incorrecto,";

                }
            
            return new JsonResult(result);

        }



        [HttpPost("GetDatosHuella")]
        public JsonResult GetDatosHuella([FromBody] DatosHuellaModel request)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var resultado =  _loginService.GetDatosHuella(request.Id);
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.message = "Informacion registrada con exito";
                objectResponse.success = true;
                objectResponse.response = new
                {
                    data = resultado
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