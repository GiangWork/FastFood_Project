﻿using FastFood.Contract.Repositories.Entity;
using FastFood.Core.Utils;
using Microsoft.AspNetCore.Identity;

namespace FastFood.Repositories.Entity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Password { get; set; } = string.Empty;
        public virtual UserInfo? UserInfo { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }
        public ApplicationUser()
        {
            CreatedTime = CoreHelper.SystemTimeNow;
            LastUpdatedTime = CreatedTime;
        }
    }
}