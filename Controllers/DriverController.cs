using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing.Printing;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimplifiedDMV.Data;
using SimplifiedDMV.Helper;
using SimplifiedDMV.Models;
using SimplifiedDMV.Models.ViewModels;

namespace SimplifiedDMV.Controllers
{
    public class DriverController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DriverController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchText = "", int pageNumber = 1)
        {
            IQueryable<Driver> objDriverList;
            string FirstNameToSearch = searchText.Trim();
            if (FirstNameToSearch != "" && FirstNameToSearch != null)
            {
                objDriverList = from driver in _db.Drivers
                                where driver.FirstName.Contains(FirstNameToSearch)
                                                select driver;
            }
            else
                objDriverList = _db.Drivers;
            if (objDriverList != null)
            {
                objDriverList.OrderBy(driver => driver.Id);
                return View(await PaginatedList<Driver>.CreateAsync(objDriverList, pageNumber, 8));
            }
            else
                return View(new PaginatedList<Vehicle>(null, 0, pageNumber, 8));

        }
        //Get
        public IActionResult Create()
        {
            var statesList = States.GetAll();
            var driverViewModel = new DriverViewModel();
            driverViewModel.StatesSelectList = new List<SelectListItem>();
            foreach(var state in statesList)
            {
                driverViewModel.StatesSelectList.Add(new SelectListItem { Text = state.Name, Value = state.Id });
            }

            return View(driverViewModel);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DriverViewModel obj)
        {
            if (ModelState.IsValid)
            {
                Driver driverToCreate = obj.DriverModel;
                _db.Drivers.Add(driverToCreate);
                _db.SaveChanges();
                TempData["success"] = "Driver created sucessfully!";
                return RedirectToAction("Index");
            }
            else
            {
                var statesList = States.GetAll();
                obj.StatesSelectList = new List<SelectListItem>();
                foreach (var state in statesList)
                {
                    obj.StatesSelectList.Add(new SelectListItem { Text = state.Name, Value = state.Id });
                }
                TempData["error"] = "Driver creation failed!";
                return View(obj);
            }
        }
        //GET
        public async Task<IActionResult> Detail(int id, int pageNumber = 1)
        {
            var vehiclesViewModel = new VehiclesViewModel();
            vehiclesViewModel.DriverId = id;
            IQueryable<Vehicle> objVehicleList;
            //Driver driverForDetails = _db.Drivers.Include(driv => driv.Vehicles).Single(driv => driv.Id == id);
            //objVehicleList = driverForDetails.Vehicles;
            objVehicleList = _db.Vehicles.Include(c => c.Driver).Where(c => c.DriverId == id);
            if (objVehicleList != null)
            {
                vehiclesViewModel.VehiclesToDisplay = await PaginatedList<Vehicle>.CreateAsync(objVehicleList.AsQueryable(), pageNumber, 8);
            }
            else
                vehiclesViewModel.VehiclesToDisplay = new PaginatedList<Vehicle>(null, 0, pageNumber, 8);
            return View(vehiclesViewModel);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            var statesList = States.GetAll();
            var driverViewModel = new DriverViewModel();
            var DriverFromDb = _db.Drivers.Find(id);
            driverViewModel.StatesSelectList = new List<SelectListItem>();
            driverViewModel.DriverModel = DriverFromDb;
            foreach (var state in statesList)
            {
                driverViewModel.StatesSelectList.Add(new SelectListItem { Text = state.Name, Value = state.Id });
            }
            return View(driverViewModel);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DriverViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Drivers.Update(obj.DriverModel);
                _db.SaveChanges();
                TempData["success"] = "Driver is Updated sucessfully!";
                return RedirectToAction("Index");
            }
            else
            {
                var statesList = States.GetAll();
                obj.StatesSelectList = new List<SelectListItem>();
                foreach (var state in statesList)
                {
                    obj.StatesSelectList.Add(new SelectListItem { Text = state.Name, Value = state.Id });
                }
                TempData["error"] = "Driver creation failed!";
                return View(obj);
            }
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var DriverFromDb = _db.Drivers.Find(id);
            if (DriverFromDb == null)
            {
                return NotFound();
            }

            return View(DriverFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var DriverToDelete = _db.Drivers.Find(id);
            if (DriverToDelete == null)
            {
                return NotFound();
            }
            _db.Drivers.Remove(DriverToDelete);
            _db.SaveChanges();
            TempData["success"] = "Driver deleted sucessfully!";
            return RedirectToAction("Index");
        }
        
    }
}
