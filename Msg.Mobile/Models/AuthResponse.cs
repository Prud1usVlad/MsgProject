﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
        public string UserId { get; set; }
    }
}
