using System.ComponentModel.DataAnnotations;

namespace _2302b1testAPI.Models
{
    //Data Transfer Object

    public class StudentDTO
    {

        [Required]
        public string Name { get; set; } = null!;


        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string ContactNo { get; set; } = null!;
    }
}
