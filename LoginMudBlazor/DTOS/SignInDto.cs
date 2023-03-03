using System.ComponentModel.DataAnnotations;

namespace LoginMudBlazor.DTOS
{
    public class SignInDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
