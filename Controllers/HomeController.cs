using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ISSR_MVC.Models;

namespace ISSR_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

        //HttpContext.Session.SetInt32("Counter", HttpContext.Session.GetInt32("Counter").GetValueOrDefault(0));
        
    }

    [HttpGet]
    public IActionResult Index()
    {
        int counter = HttpContext.Session.GetInt32("Counter").GetValueOrDefault(0);
        ViewData["Counter"] = counter;
        return View();
    }

    [HttpPost]
    public ActionResult Index(IFormCollection collection)
    {
        try
        {
            //Method 1: Using Component Name  
                
            //bool doAdd = !String.IsNullOrEmpty(collection["addx"]);
            //bool doSub = !String.IsNullOrEmpty(collection["subx"]);

            int counter = HttpContext.Session.GetInt32("Counter").GetValueOrDefault(0);
            if(collection["addx"] == "T")
            {
                counter++;
            }
            if(collection["subx"] == "T" && counter > 0)
            {
                counter--;
            }
            //GlobalVariables.Counter = counter;
            HttpContext.Session.SetInt32("Counter", counter);
            ViewData["Counter"] = counter;

/*
            for (int i = 0; i < counter; i++)
            {
                counterString += "<li>" + i.ToString + "</li>";
            }
*/
            //ViewData["Add"] = collection["addx"];
            //ViewData["Sub"] = collection["subx"];
            //string s = collection["addx"];
            //Method 2: Using Component Index Position
            //ViewData["Name"] = collection[1];
    
            return View("Index");
        }
        catch
        {
            return View();
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
