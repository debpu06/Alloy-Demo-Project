using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Documentation.Plugin.Repository.Models
{
    public class GithubResponse
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "encoding")]
        public string Encoding { get; set; }
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
        [JsonProperty(PropertyName = "sha")]
        public string Sha { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "git_url")]
        public string GitUrl { get; set; }
        [JsonProperty(PropertyName = "html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty(PropertyName = "download_url")]
        public string DownloadUrl { get; set; }
        [JsonProperty(PropertyName = "_links")]
        public Links Links { get; set; }
    }

    public class Links
    {
        [JsonProperty(PropertyName = "git")]
        public string Git { get; set; }
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }
        [JsonProperty(PropertyName = "html")]
        public string Html { get; set; }
    }
}
