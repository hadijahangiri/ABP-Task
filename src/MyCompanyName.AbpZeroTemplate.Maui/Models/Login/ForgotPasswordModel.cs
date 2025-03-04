using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.Maui.Models.Login
{
    public class ForgotPasswordModel
    {
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
    }
}
