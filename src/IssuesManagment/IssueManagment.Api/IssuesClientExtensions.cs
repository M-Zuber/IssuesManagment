using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace IssuesManagment.Clients
{
    public static class IssuesClientExtensions
    {
        public static async Task<IssueWithComments> GetWithComments(this IIssuesClient client, string owner, string name, int number)
        {
            var issue = await client.Get(owner, name, number);
            var comments = await client.Comment.GetAllForIssue(owner, name, issue.Number);

            return IssueWithComments.FromIssue(issue, comments);
        }

        public static async Task<IReadOnlyList<IssueWithComments>> GetAllForCurrentWithComments(this IIssuesClient client)
        {
            var issues = await client.GetAllForCurrent();

            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(IssueWithComments.FromIssue(i, await client.Comment.GetAllForIssue(owner, repo, i.Number)));
                }
            }

            return all.AsReadOnly();
        }

        public static async Task<IReadOnlyList<IssueWithComments>> GetAllForCurrentWithComments(this IIssuesClient client, IssueRequest request)
        {
            var issues = await client.GetAllForCurrent(request);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(IssueWithComments.FromIssue(i, await client.Comment.GetAllForIssue(owner, repo, i.Number)));
                }
            }

            return all.AsReadOnly();
        }

        public static async Task<IReadOnlyList<IssueWithComments>> GetAllForOrganizationWithComments(this IIssuesClient client, string organization)
        {
            var issues = await client.GetAllForOrganization(organization);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(IssueWithComments.FromIssue(i, await client.Comment.GetAllForIssue(owner, repo, i.Number)));
                }
            }

            return all.AsReadOnly();
        }

        public static async Task<IReadOnlyList<IssueWithComments>> GetAllForOrganizationWithComments(this IIssuesClient client, string organization, IssueRequest request)
        {
            var issues = await client.GetAllForOrganization(organization, request);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(IssueWithComments.FromIssue(i, await client.Comment.GetAllForIssue(owner, repo, i.Number)));
                }
            }

            return all.AsReadOnly();
        }

        public static async Task<IReadOnlyList<IssueWithComments>> GetAllForOwnedAndMemberRepositoriesWithComments(this IIssuesClient client)
        {
            var issues = await client.GetAllForOwnedAndMemberRepositories();
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(IssueWithComments.FromIssue(i, await client.Comment.GetAllForIssue(owner, repo, i.Number)));
                }
            }

            return all.AsReadOnly();
        }

        public static async Task<IReadOnlyList<IssueWithComments>> GetAllForOwnedAndMemberRepositoriesWithComments(this IIssuesClient client, IssueRequest request)
        {
            var issues = await client.GetAllForOwnedAndMemberRepositories(request);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(IssueWithComments.FromIssue(i, await client.Comment.GetAllForIssue(owner, repo, i.Number)));
                }
            }

            return all.AsReadOnly();
        }

        public static async Task<IReadOnlyList<IssueWithComments>> GetAllForRepositoryWithComments(this IIssuesClient client, string owner, string name)
        {
            var issues = await client.GetAllForRepository(owner, name);
            List<IssueWithComments> all = new List<IssueWithComments>();

            foreach (var i in issues)
            {
                all.Add(IssueWithComments.FromIssue(i, await client.Comment.GetAllForIssue(owner, name, i.Number)));
            }

            return all;
        }

        public static async Task<IReadOnlyList<IssueWithComments>> GetAllForRepositoryWithComments(this IIssuesClient client, string owner, string name, RepositoryIssueRequest request)
        {
            var issues = await client.GetAllForRepository(owner, name, request);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var i in issues)
            {
                all.Add(IssueWithComments.FromIssue(i, await client.Comment.GetAllForIssue(owner, name, i.Number)));
            }

            return all.AsReadOnly();
        }
    }
}
