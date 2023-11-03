using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Category? Category { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
    }
}
