﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRTest.Models
{
    
    public class UserLogin
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        
    }
}
