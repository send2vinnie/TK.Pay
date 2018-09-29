﻿using System.ComponentModel.DataAnnotations;
using Abp.Application.Editions;
using Abp.AutoMapper;

namespace TK.Pay.Editions.Dto
{
    [AutoMap(typeof(Edition))]
    public class EditionEditDto
    {
        public int? Id { get; set; }

        [Required]
        public string DisplayName { get; set; }
    }
}