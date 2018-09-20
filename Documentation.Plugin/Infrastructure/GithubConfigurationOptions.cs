using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentation.Plugin.Interfaces;

namespace Documentation.Plugin.Infrastructure
{
    public class GithubConfigurationOptions : IConfigurationOptions
    {
        public string GithubRepositoryOwner { get; set; }
        public string GithubRepositoryName { get; set; }
        public string GithubApiToken { get; set; }
        public string GithubDocumentationFolder { get; set; }
        public string GithubBranch { get; set; }
    }
}
