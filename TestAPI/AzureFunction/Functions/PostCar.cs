using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunction.Controllers;
using Application.Interaces;
using Domain.Entities;

namespace AzureFunction.Functions
{
    public static class PostCar
    {
        public static ICarCosmosService _carCosmosService;
        public static CarController _carController;

        [FunctionName("PostCar")]
        public static IActionResult Run(HttpRequest req, out object taskDocument, ILogger log, ICarCosmosService carCosmosService, CarController carController)
        {
            string id = req.Query["id"];
            string make = req.Query["make"];
            string model = req.Query["model"];

            // We need both name and task parameters.
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(make))
            {
                taskDocument = new
                {
                    id,
                    make,
                    model
                };
                _carCosmosService = carCosmosService;
                _carController = carController;
                return CarController.Post(taskDocument);
            }
            else
            {
                taskDocument = null;
                return (ActionResult)new BadRequestResult();
            }
        }
    }
}
