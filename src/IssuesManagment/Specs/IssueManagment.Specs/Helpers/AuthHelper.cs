using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace IssueManagment.Specs.Helpers
{
    public static class AuthHelper
    {
        static readonly Lazy<Credentials> _credentialsThunk = new Lazy<Credentials>(() =>
        {
            var githubUsername = Environment.GetEnvironmentVariable("OCTOKIT_GITHUBUSERNAME");
            UserName = githubUsername;
            Organization = Environment.GetEnvironmentVariable("OCTOKIT_GITHUBORGANIZATION");

            var githubToken = Environment.GetEnvironmentVariable("OCTOKIT_OAUTHTOKEN");

            if (githubToken != null)
                return new Credentials(githubToken);

            var githubPassword = Environment.GetEnvironmentVariable("OCTOKIT_GITHUBPASSWORD");

            if (githubUsername == null || githubPassword == null)
                return null;

            return new Credentials(githubUsername, githubPassword);
        });

        public static string UserName { get; private set; }
        public static string Organization { get; private set; }
        public static Credentials Credentials { get { return _credentialsThunk.Value; } }

        public static IGitHubClient GetAnonymousClient()
        {
            return new GitHubClient(new ProductHeaderValue("IssuesManagment.Specs"));
        }

        public static IGitHubClient GetAuthenticatedClient()
        {
            return new GitHubClient(new ProductHeaderValue("OctokitTests"))
            {
                Credentials = Credentials
            };
        }

    }
}
