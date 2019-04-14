using App.BLL.Models;
using App.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Address.WebUI.Controllers
{
    public class SubdivisionController : Controller
    {
        IGenericService<SubdivisionDTO> subdivisionService; 

        public SubdivisionController(IGenericService<SubdivisionDTO> subdivisionService)
        {
            this.subdivisionService = subdivisionService;
        }

        // GET: Street
        public ActionResult Index()
        {
            var model = subdivisionService.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SubdivisionDTO model = (id == 0) ? new SubdivisionDTO() : subdivisionService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SubdivisionDTO obj)
        {
            if (ModelState.IsValid)
            {
                subdivisionService.Add(obj);
                subdivisionService.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                subdivisionService.Delete(id);
                subdivisionService.Save();
                return Json("OK");
            }
            catch
            {
                return Json("BAD");
            }
        }
    }
}