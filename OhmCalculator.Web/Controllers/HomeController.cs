using OhmCalculator.Web.Models;
using OhmCalculator.Web.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OhmCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        protected IOhmValueCalculator _ohmValCalculator;

        public HomeController(IOhmValueCalculator ohmValCalculator) {
            _ohmValCalculator = ohmValCalculator;
        }

        public ActionResult Index()
        {
            return View(new LookupOhmModel());
        }

        [HttpPost]
        public JsonResult LookupOhmValue(LookupOhmModel model) {
            //if (!ModelState.IsValid)

            int ohmValue = _ohmValCalculator.CalculateOhmValue(model.BandAColor, model.BandBColor, model.BandCColor, model.BandDColor);

            return Json(new LookupOhmValueResponse {
                Status = true,
                OhmValue = ohmValue
            });
        }
    }
}