using Documentation.Plugin.Core.Interfaces;

namespace Documentation.Plugin.Confluence.Models
{
    /// <summary>
    /// Confluence configuration options
    /// </summary>
    public class ConfluenceConfigurationOptions : IConfigurationOptions
    {
        public string BaseUrl { get; set; }
        public string Username { get; set; }
        public string Key { get; set; }
        public int DefaultTimeout { get; set; }
    }
}
