using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Uber.Domain.Models;
using Uber.Services.Interface;

namespace Uber.Web.Controllers
{
    public class DriverController : Controller
    {

        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var drivers = _driverService.GetAll();
            return View(drivers);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var driver = _driverService.GetById(id);
            return View(driver);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _driverService.Create(driver);
                return RedirectToAction("Index");
            }

            return View(driver);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var driver = _driverService.GetById(id);
            return View(driver);
        }

        [HttpPost]
        public ActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _driverService.Update(driver);
                return RedirectToAction("Index");
            }

            return View(driver);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var driver = _driverService.GetById(id);
            return View(driver);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _driverService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
