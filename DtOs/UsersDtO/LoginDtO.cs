using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GYMmanagement.DtOs.UsersDtO
{
    public class LoginDtO
    {
        [Required]
        public string? Username { get; set; } = string.Empty;
        [Required]

        public string? Password { get; set; } = string.Empty;
    }
}
