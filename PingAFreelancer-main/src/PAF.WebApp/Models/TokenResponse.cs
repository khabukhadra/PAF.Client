using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAF.MobileApp.Models;

public class TokenResponse
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
}