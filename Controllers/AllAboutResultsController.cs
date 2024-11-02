using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace InTheBag.Controllers
{
    public class AllAboutResultsController : Controller
    {
        public IActionResult Index()
        {
            var weekday = DateTime.Now.DayOfWeek;
            var day = weekday.ToString();
            var time = DateTime.Now.Hour;


            if (time <= 6)
            {
                HttpContext.Session.SetString("greet","It is tooo early to be up!");
            }
            else if (time <= 12)
            {
                HttpContext.Session.SetString("greet","Good Morning");
            }
            else if (time <= 18)
            {
                HttpContext.Session.SetString("greet", "Good Afternoon");
            }
            else
            {
                HttpContext.Session.SetString("greet", "Good Evening");
            }
            int route = 0;

            //day = "Friday";

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                    HttpContext.Session.SetString("dayMsg", "The work week just started! Stay focused, you have a lot to do this week!");
                    route = 1;
                    break;
                case "Wednesday":
                    HttpContext.Session.SetString("dayMsg", "Half way to the weekend");
                    route = 2;
                    break;
                case "Thursday":
                    HttpContext.Session.SetString("dayMsg", "Isn't it Friday somewhere?");
                    route = 3;
                    break;
                case "Friday":
                    HttpContext.Session.SetString("dayMsg", "Woo hoo TGIF");
                    route = 4;
                    break;
                default:
                    HttpContext.Session.SetString("dayMsg", "Ahhhhh the weekend!");
                    route = 5;
                    break;

            }

            if (route == 1)
            {
                return RedirectToAction("Weekday", "AllAboutResults");
            }
            else if (route == 2 || route == 3)
            {
                return Redirect("https://lisabalbach.com/CIT218/Chapter8/HappyWednesday.html");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Weekday()
        {
            HttpContext.Session.SetString("greet", "Congratulations, the work week just started and you have been rerouted!");
            return View();
        }
    }
}