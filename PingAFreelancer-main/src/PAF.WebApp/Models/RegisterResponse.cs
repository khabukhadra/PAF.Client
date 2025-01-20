using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAF.MobileApp.Models;

public class RegisterResponse
{
    public bool Success { get; set; }
    public List<Error> Errors { get; set; } = new List<Error>();
}

public class Error
{
    public string Code { get; set; } 

    public string Description { get; set; }
}
