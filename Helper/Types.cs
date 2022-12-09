using SimplifiedDMV.Models.DomainModels;

namespace SimplifiedDMV.Helper
{
    public class Types
    {
        public static List<SimplifiedDMV.Models.DomainModels.Type> GetAll()
        {
            return new List<SimplifiedDMV.Models.DomainModels.Type>
            {
                new SimplifiedDMV.Models.DomainModels.Type(){Id = "1", Name = "SUV"},
                new SimplifiedDMV.Models.DomainModels.Type(){Id = "2", Name = "Crossover"},
                new SimplifiedDMV.Models.DomainModels.Type() { Id = "3", Name = "Sedan"},
                new SimplifiedDMV.Models.DomainModels.Type() { Id = "4", Name = "Truck"},
                new SimplifiedDMV.Models.DomainModels.Type() { Id = "5", Name = "Wagon"},
                new SimplifiedDMV.Models.DomainModels.Type() { Id = "6", Name = "Convertible"},
                new SimplifiedDMV.Models.DomainModels.Type() { Id = "7", Name = "Coupe"},
                new SimplifiedDMV.Models.DomainModels.Type() { Id = "8", Name = "Van"},
                new SimplifiedDMV.Models.DomainModels.Type() { Id = "9", Name = "Electric"}
            };
        }
    }
}
