using System.ComponentModel.DataAnnotations;

namespace Domain.Requests.Identity
{
    public class ChangePasswordRequest
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}