using System.ComponentModel.DataAnnotations;

namespace SmartPhonesAPI.Models
{
    public class SmartPhone
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Feature is required")]
        public string Features { get; set; }
        [Required(ErrorMessage = "Luanch Date is required")]
        public DateTime LauchDate { get; set; }
        [Range(500, Double.MaxValue, ErrorMessage =$"Value must be greater than 500")]
        public double Price { get; set; }
    }
}
