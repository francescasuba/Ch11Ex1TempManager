using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TempManager.Models;

namespace TempManager.Controllers
{
    public class ValidationController : Controller
    {
        private TempManagerContext context;
        public ValidationController(TempManagerContext ctx) => context = ctx;
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CheckDate(string date)
        {
            DateTime convertedDate = DateTime.Parse(date);
            Temp msg = context.Temps.FirstOrDefault(t => t.Date == convertedDate);
            if (msg == null)
            {
                return Json(true);
            }
            else return Json("Date is already in the database");
        }

       
    }
}
