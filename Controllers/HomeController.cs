using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Random rd = new Random();
            string CreateString()
            {
                const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
                char[] chars = new char[14];

                for (int i = 0; i < 14; i++)
                {
                    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                }

                return new string(chars);
            }
            string randCode = CreateString();

            HttpContext.Session.SetString("Passcode", randCode);

            ViewBag.Code = HttpContext.Session.GetString("Passcode");

            return View("Index");
        }

        [HttpPost("generate")]
        public IActionResult Generate()
        {
            return RedirectToAction("Index");
        }
        
    }
}
