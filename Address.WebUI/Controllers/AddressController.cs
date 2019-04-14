using App.BLL.Models;
using App.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Address.WebUI.Controllers
{
    public class AddressController : Controller
    {
        IGenericService<AddressDTO> addressService;

        public AddressController(IGenericService<AddressDTO> addressService)
        {
            this.addressService = addressService;
        }
        // GET: Address
        public ActionResult Index()
        {
            IEnumerable<AddressDTO> model = addressService.GetAll();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            AddressDTO model = (id == 0) ? new AddressDTO() : addressService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddressDTO obj)
        {
            if (ModelState.IsValid)
            {
                addressService.Add(obj);
                addressService.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                addressService.Delete(id);
                addressService.Save();
                return Json("OK");
            }
            catch
            {
                return Json("BAD");
            }
        }

        public ActionResult Details(int id)
        {
            AddressDTO address = addressService.Get(id);
            return View(address);
        }
    }
}