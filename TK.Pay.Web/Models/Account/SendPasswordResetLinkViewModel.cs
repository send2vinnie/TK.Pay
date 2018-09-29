using System.ComponentModel.DataAnnotations;

namespace TK.Pay.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        public string TenancyName { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}