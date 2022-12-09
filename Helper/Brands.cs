using SimplifiedDMV.Models.DomainModels;
namespace SimplifiedDMV.Helper
{
    public class Brands
    {
        public static List<Brand> GetAll()
        {
            return new List<Brand>
            {
                new Brand(){Id = "1", Name = "Audi"},
                new Brand(){Id = "2", Name = "BMW"},
                new Brand(){Id = "3", Name = "Buick"},
                new Brand(){Id = "4", Name = "Cadillac"},
                new Brand(){Id = "5", Name = "Chevrolet"},
                new Brand(){Id = "6", Name = "Chrysler"},
                new Brand(){Id = "7", Name = "Dodge"},
                new Brand(){Id = "8", Name = "Ford"},
                new Brand(){Id = "9", Name = "GMC"},
                new Brand(){Id = "10", Name = "Honda"},
                new Brand(){Id = "11", Name = "Hyundai"},
                new Brand(){Id = "12", Name = "INFINITI"},
                new Brand(){Id = "13", Name = "Jaguar"},
                new Brand(){Id = "14", Name = "Jeep"},
                new Brand(){Id = "15", Name = "Land Rovor"},
                new Brand(){Id = "16", Name = "Sunbeam"},
                new Brand(){Id = "17", Name = "Suzuki"},
                new Brand(){Id = "18", Name = "Triumph"},
                new Brand(){Id = "19", Name = "Willys"},
            };
        }
    }
}
