﻿using System;
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
            //TODO switch from settings to using Enviroment Variables

            var githubUsername = IssueManagment.Specs.Properties.Settings.Default.IssuesManagment_GITHUBUSERNAME;
            UserName = githubUsername;
            Organization = IssueManagment.Specs.Properties.Settings.Default.IssuesManagment_GITHUBORGANIZATION;

            var githubToken = IssueManagment.Specs.Properties.Settings.Default.IssuesManagment_OAUTHTOKEN;

            if (!string.IsNullOrWhiteSpace(githubToken))
                return new Credentials(githubToken);

            var githubPassword = IssueManagment.Specs.Properties.Settings.Default.IssuesManagment_GITHUBPASSWORD;

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