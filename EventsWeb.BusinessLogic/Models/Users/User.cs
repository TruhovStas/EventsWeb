﻿using Microsoft.AspNetCore.Identity;

namespace EventsWeb.BusinessLogic.Models.Users
{
    public class User : IdentityUser<int>
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
