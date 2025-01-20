using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAF.MobileApp.Models
{
    public class NavItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string[] RolesRequired { get; set; }
    }
}