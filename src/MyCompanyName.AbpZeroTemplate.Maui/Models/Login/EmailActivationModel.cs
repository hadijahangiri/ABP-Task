using System.ComponentModel.DataAnnotations;
using MyCompanyName.AbpZeroTemplate.Validation;

namespace MyCompanyName.AbpZeroTemplate.Maui.Models.Login
{
    public class EmailActivationModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
