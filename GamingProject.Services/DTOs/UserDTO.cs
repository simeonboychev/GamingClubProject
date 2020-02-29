using System;
using System.Collections.Generic;
using System.Text;

namespace GamingProject.Services.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string SessionId { get; set; }
        public bool IsInSession { get; set; }
        public string IdentificationNumber { get; set; }
        public string CurrentDeviceType { get; set; }
        public string CurrentDeviceName { get; set; }
        
        public DateTime RegisteredOn { get; set; }
    }
}
