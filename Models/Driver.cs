using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SimplifiedDMV.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Phone number")]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(30)]
        public string State { get; set; }
        [DisplayName("Zip code")]
        [MaxLength(8)]
        public string ZipCode { get; set; }
        [DisplayName("Register date")]
        public DateTime RegisteredDateTime { get; set; } = DateTime.Now;

        public IList<Vehicle>? Vehicles { get; set; }
    }
}
