using Documentation.Plugin.Core.Interfaces;

namespace Documentation.Plugin.Github.Models
{
    /// <summary>
    /// Github repository conifiguration options
    /// </summary>
    public class GithubConfigurationOptions : IConfigurationOptions
    {
        public string GithubRepositoryOwner { get; set; }
        public string GithubRepositoryName { get; set; }
        public string GithubApiToken { get; set; }
        public string GithubDocumentationFolder { get; set; }
        public string GithubBranch { get; set; }
    }
}
