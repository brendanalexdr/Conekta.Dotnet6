﻿using Conekta.Dotnet6;
using Conekta.Dotnet6.Util;
using DemoWebApi.Config;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConektaRestClient _conektaRestClient;
        private readonly ConektaPrivateKey _conektaPrivateKey;

        public HomeController(IConektaRestClient conektaRestClient, ConektaPrivateKey conektaPrivateKey)
        {
            _conektaRestClient = conektaRestClient;
            _conektaPrivateKey = conektaPrivateKey;
}

        [HttpGet("customer/{id}")]
        public async Task<ActionResult> GetCustomerAsync(string id)
        {   

            var conektaApi = new ConektaApi("en", _conektaPrivateKey.Value, _conektaRestClient);
            
            var customer = await conektaApi.GetCustomerAsync(id);

            if (customer.IsFailure)
            {
                return Content(customer.Error.message);
            }


            return Json(customer.Value);
        }
    }
}
