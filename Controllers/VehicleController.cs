using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimplifiedDMV.Helper;
using SimplifiedDMV.Models.ViewModels;
using SimplifiedDMV.Models;
using SimplifiedDMV.Data;

namespace SimplifiedDMV.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VehicleController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Get
        public IActionResult Create(int id)
        {

            var typeList = Types.GetAll();
            var brandList = Brands.GetAll();
            var yearList = Years.GetAll();
            Vehicle vehicleModel = new Vehicle();
            vehicleModel.DriverId = id;

            var registerVehicleViewModel = new RegisterVehicleViewModel();

            registerVehicleViewModel.TypesSelectList = new List<SelectListItem>();
            registerVehicleViewModel.BrandsSelectList = new List<SelectListItem>();
            registerVehicleViewModel.YearsSelectList = new List<SelectListItem>();
            registerVehicleViewModel.DriverId = id;
            registerVehicleViewModel.VehicleModel= vehicleModel;

            foreach (var type in typeList)
            {
                registerVehicleViewModel.TypesSelectList.Add(new SelectListItem { Text = type.Name, Value = type.Name });
            }
            foreach (var brand in brandList)
            {
                registerVehicleViewModel.BrandsSelectList.Add(new SelectListItem { Text = brand.Name, Value = brand.Name });
            }
            foreach (var year in yearList)
            {
                registerVehicleViewModel.YearsSelectList.Add(new SelectListItem { Text = year.Name, Value = year.Name });
            }

            return View(registerVehicleViewModel);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegisterVehicleViewModel obj)
        {
            int dirverId = obj.DriverId;
            try { 
                _db.Vehicles.Add(obj.VehicleModel);
                _db.SaveChanges();
                TempData["success"] = "Vehicle registered sucessfully!";
                return RedirectToAction("Detail", "Driver", new {id = dirverId});
            }
            catch(Exception ex) 
            {
                var typeList = Types.GetAll();
                var brandList = Brands.GetAll();
                var yearList = Years.GetAll();


                obj.TypesSelectList = new List<SelectListItem>();
                obj.BrandsSelectList = new List<SelectListItem>();
                obj.YearsSelectList = new List<SelectListItem>();

                foreach (var type in typeList)
                {
                    obj.TypesSelectList.Add(new SelectListItem { Text = type.Name, Value = type.Name });
                }
                foreach (var brand in brandList)
                {
                    obj.BrandsSelectList.Add(new SelectListItem { Text = brand.Name, Value = brand.Name });
                }
                foreach (var year in yearList)
                {
                    obj.YearsSelectList.Add(new SelectListItem { Text = year.Name, Value = year.Name });
                }
                TempData["error"] = "Vehicle registration failed!";
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int id)
        {
            var typeList = Types.GetAll();
            var brandList = Brands.GetAll();
            var yearList = Years.GetAll();

            var registerVehicleViewModel = new RegisterVehicleViewModel();

            registerVehicleViewModel.TypesSelectList = new List<SelectListItem>();
            registerVehicleViewModel.BrandsSelectList = new List<SelectListItem>();
            registerVehicleViewModel.YearsSelectList = new List<SelectListItem>();
            registerVehicleViewModel.DriverId = _db.Vehicles.Find(id).DriverId;
            registerVehicleViewModel.VehicleModel = _db.Vehicles.Find(id);
            foreach (var type in typeList)
            {
                registerVehicleViewModel.TypesSelectList.Add(new SelectListItem { Text = type.Name, Value = type.Name });
            }
            foreach (var brand in brandList)
            {
                registerVehicleViewModel.BrandsSelectList.Add(new SelectListItem { Text = brand.Name, Value = brand.Name });
            }
            foreach (var year in yearList)
            {
                registerVehicleViewModel.YearsSelectList.Add(new SelectListItem { Text = year.Name, Value = year.Name });
            }

            return View(registerVehicleViewModel);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RegisterVehicleViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Vehicles.Update(obj.VehicleModel);
                _db.SaveChanges();
                TempData["success"] = "Vehicle is Updated sucessfully!";
                return RedirectToAction("Detail", "Driver", new { id = obj.DriverId });
            }
            else
            {
                var typeList = Types.GetAll();
                var brandList = Brands.GetAll();
                var yearList = Years.GetAll();


                obj.TypesSelectList = new List<SelectListItem>();
                obj.BrandsSelectList = new List<SelectListItem>();
                obj.YearsSelectList = new List<SelectListItem>();
 
                foreach (var type in typeList)
                {
                    obj.TypesSelectList.Add(new SelectListItem { Text = type.Name, Value = type.Name });
                }
                foreach (var brand in brandList)
                {
                    obj.BrandsSelectList.Add(new SelectListItem { Text = brand.Name, Value = brand.Name });
                }
                foreach (var year in yearList)
                {
                    obj.YearsSelectList.Add(new SelectListItem { Text = year.Name, Value = year.Name });
                }
                TempData["error"] = "Vehicle update failed!";
                return View(obj);
            }

        }
        //GET
        public IActionResult Delete(int id)
        {
            var registerVehicleViewModel = new RegisterVehicleViewModel();
            registerVehicleViewModel.DriverId = _db.Vehicles.Find(id).DriverId;
            registerVehicleViewModel.VehicleId = _db.Vehicles.Find(id).Id;
            registerVehicleViewModel.VehicleModel = _db.Vehicles.Find(id);

            return View(registerVehicleViewModel);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(RegisterVehicleViewModel obj)
        {
            var VehicleToDelete = _db.Vehicles.Find(obj.VehicleId);
            try
            {
                _db.Vehicles.Remove(VehicleToDelete);
                _db.SaveChanges();
                TempData["success"] = "Vehicle deleted sucessfully!";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Vehicle deleted sucessfully!";
            }
            return RedirectToAction("Detail", "Driver", new { id = obj.DriverId });
        }
    }
}
