using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SimplifiedDMV.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Vin Number")]
        [StringLength(100)]
        public string VinNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        [StringLength(30)]
        public string Brand { get; set; }
        [Required]
        [StringLength(30)]
        public string Model { get; set; }
        [Required]
        [StringLength(10)]
        public string Year { get; set; }
        [DisplayName("Register date")]
        public DateTime RegisteredDateTime { get; set; } = DateTime.Now;
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
    }
}
