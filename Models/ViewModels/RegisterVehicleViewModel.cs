using Microsoft.AspNetCore.Mvc.Rendering;
using SimplifiedDMV.Models.DomainModels;

namespace SimplifiedDMV.Models.ViewModels
{
    public class RegisterVehicleViewModel
    {
        public List<SelectListItem>? TypesSelectList { get; set; }
        public List<SelectListItem>? BrandsSelectList { get; set; }
        public List<SelectListItem>? YearsSelectList { get; set; }

        public Vehicle VehicleModel { get; set; }
        public int DriverId { get; set; }

        public int? VehicleId { get; set; }
    }
}

