using System.ComponentModel.DataAnnotations;

namespace LoginMudBlazor.DTOS
{
    public class SignUpDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
