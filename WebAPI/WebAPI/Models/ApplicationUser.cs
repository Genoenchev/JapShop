﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string? FullName { get; set; }
    }
}
