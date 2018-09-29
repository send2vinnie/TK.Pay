using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using TK.Pay.Authorization.Users;

namespace TK.Pay.Configuration.Host.Dto
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}