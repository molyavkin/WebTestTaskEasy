using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreSession.Models;

namespace WebAppCoreSession.Controllers
{
    

    public class HomeController : Controller
    {
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      

               
        [HttpGet]
        public IActionResult Number()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Number(int number)
        {
            
            //ViewBag.value = number;
            
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.message = "HttpGet";
            int n = 0;
            ViewBag.flag = -1;
            HttpContext.Session.SetInt32("user", n);
            ViewBag.sessionId = HttpContext.Session.GetSessionName("user");
            ViewBag.sessionUser = HttpContext.Session.Id.ToString();
            ViewBag.number = (int)HttpContext.Session.GetInt32("user");
            ViewBag.lines = new List<string> { "", "" };
            ViewBag.currentInfo = "";

            return View();

        }
        [HttpPost]
        public IActionResult Index(int number)
        {
            string SessionKeyName = "user";
           // string SessionKeyXMLString = "XMLString";
           
            ViewBag.lines = new List<string> { "", "" };
            ViewBag.currentInfo = "";

            ViewBag.flag = 1;

           
            if (number == 0)
            {
                Actors myActor = ManageUser.InitializeData();
                HttpContext.Session.SetObjectAsJson(SessionKeyName, myActor);
                
            }
            ViewBag.value = number;
            Actors myComplexObject = HttpContext.Session.GetObjectFromJson<Actors>(SessionKeyName);
            
            if (myComplexObject != null && number != 0)
            {
                myComplexObject.AddNextNumbers(number);
                //string[] lines = myComplexObject.PrintAllInfo();
                ViewBag.currentInfo = myComplexObject.CurrentInfo();
                ViewBag.draw = "______________________________________________________";
                ViewBag.hystory = "История догадок:";
                ViewBag.lines = myComplexObject.PrintAllInfo();
                HttpContext.Session.SetObjectAsJson(SessionKeyName, myComplexObject);
                ViewBag.text = "Догадки экстрасенсов:";
                ViewBag.currentRating = myComplexObject.CurrentRating();
            }
            
           
           
            return View();
        }
        //https://docs.microsoft.com/ru-ru/aspnet/core/mvc/views/view-components?view=aspnetcore-2.0
    }
}
