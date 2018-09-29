using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace TK.Pay.Editions.Dto
{
    public class CreateOrUpdateEditionDto
    {
        [Required]
        public EditionEditDto Edition { get; set; }

        [Required]
        public List<NameValueDto> FeatureValues { get; set; }
    }
}