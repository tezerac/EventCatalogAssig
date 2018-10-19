using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCatalogAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]

    [Produces("application/json")]
    [Route("api/EventPics")]
    public class PicController : ControllerBase
    {
        private readonly IHostingEnvironment _env;

        public PicController(IHostingEnvironment env)
        {
            _env = env;
        }
        [HttpGet]//identifies a method that only supports the HTTP get method 
        [Route("{id}")]
        public IActionResult GetEventImage(int id)
        {
            var webRoot = _env.WebRootPath;
            var path = Path.Combine(webRoot + "/EventPics/", "Pic-" + id + ".PNG");
            var buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/PNG");
        }

    }
}

//to test a controller we need to have a postman app
//we need the environment to run the api 
//webroot is to show the wwwroot in the api
//path is used to combine all the paths for the picture
//controller is  a way of showing different microservices using different controllers.
//and we should always have a route and a return json type
//the curly brace shows the place holder for the url
//every communicaton with api send a huge xml file , so json is prefereble
//there fore each app will send xml file but the api will respond using a json file 
//which is a lightweight

//public class PicController: ControllerBase
//{
//    //this is a pic controler
//    //always we shoud access the api through the controllers

//}