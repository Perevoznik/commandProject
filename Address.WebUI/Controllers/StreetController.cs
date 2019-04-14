using App.BLL.Models;
using App.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Address.WebUI.Controllers
{
    public class StreetController : Controller
    {
        IGenericService<StreetDTO> streetService;

        public StreetController(IGenericService<StreetDTO> streetService)
        {
            this.streetService = streetService;
        }

        // GET: Street
        public ActionResult Index()
        {
            var model = streetService.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StreetDTO model = (id == 0) ? new StreetDTO() : streetService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StreetDTO obj)
        {
            if(ModelState.IsValid)
            {
                streetService.Add(obj);
                streetService.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                streetService.Delete(id);
                streetService.Save();
                return Json("OK");
            }
            catch
            {
                return Json("BAD");
            }
        }
    }
}