using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;
using System.Collections.Generic;
using System.Data;

namespace marcatel_api.Controllers
{
   
    [Route("api")]
    public class RegistroController: ControllerBase
    {
        private readonly RegistroService _ticketService;
        private readonly ILogger<RegistroController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        Encrypt enc = new Encrypt();

        public RegistroController(RegistroService ticketservice, ILogger<RegistroController> logger, IJwtAuthenticationService authService) {
            _ticketService = ticketservice;
            _logger = logger;
       
            _authService = authService;
        }

        
        
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("InsertRegistro")]
        public  JsonResult GetComprasVsVentas([FromBody] RegistroModel registro)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 _ticketService.InsertRegistro(registro);
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.message = "data cargado con exito";
                objectResponse.success = true;
                objectResponse.response = new
                {
                    data = true
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                objectResponse.response = new
                {
                    data = false
                    

                };
                objectResponse.message = ex.Message;
            }


            return new JsonResult(objectResponse);

        }

        

    
    }
}