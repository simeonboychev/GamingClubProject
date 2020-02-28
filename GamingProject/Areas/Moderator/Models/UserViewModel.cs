﻿using System;

namespace GamingProject.Areas.Moderator.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public TimeSpan CurrentPlaying { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public bool IsInSession { get; set; }
        public int Counter { get; set; }
        public int RemainingMinutes { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}
