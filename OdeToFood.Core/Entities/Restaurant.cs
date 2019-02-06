using System.ComponentModel.DataAnnotations;
using OdeToFood.Core.Enums;

namespace OdeToFood.Core.Entities
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
