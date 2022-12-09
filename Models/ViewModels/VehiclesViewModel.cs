using Microsoft.AspNetCore.Mvc.Rendering;
using SimplifiedDMV.Models.DomainModels;

namespace SimplifiedDMV.Models.ViewModels
{
    public class VehiclesViewModel
    {
        public PaginatedList<Vehicle> VehiclesToDisplay { get; set; }
        
        public int DriverId { get; set; }
    }
}

