using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi
{
    public class TestDTO
    {
        [Required]
        public int Val { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
