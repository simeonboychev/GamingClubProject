using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GamingProject.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MinutesPlayed { get; set; }
        public string IdentificationNumber { get; set; }
        public bool IsInSession { get; set; }
        public DateTime RegisteredOn { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
