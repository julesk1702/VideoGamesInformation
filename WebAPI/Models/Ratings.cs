using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Ratings
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public double Percent { get; set; }
    }
}
