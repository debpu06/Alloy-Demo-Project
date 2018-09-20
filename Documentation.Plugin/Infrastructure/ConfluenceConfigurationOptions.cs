using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentation.Plugin.Interfaces;

namespace Documentation.Plugin.Infrastructure
{
    public class ConfluenceConfigurationOptions : IConfigurationOptions
    {
        public string BaseUrl { get; set; }
        public string Username { get; set; }
        public string Key { get; set; }
        public int DefaultTimeout { get; set; }
    }
}
