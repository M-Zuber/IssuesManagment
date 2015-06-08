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
        public static async Task<IssueEx> GetWithComments(this IIssuesClient client, string owner, string name, int number)
        {
            var issue = await client.Get(owner, name, number);
            var comments = await client.Comment.GetAllForIssue(owner, name, issue.Number);

            return IssueEx.FromIssue(issue, comments);
        }

        public static async Task<IReadOnlyList<IssueEx>> GetAllForCurrentWithComments(this IIssuesClient client)
        {
            var issues = await client.GetAllForCurrent();

            return await Task.WhenAll(issues.Select(async i => IssueEx.FromIssue(i, await client.Comment.GetAllForIssue(i.Url.Segments[2], i.Url.Segments[3], i.Number))));
        }

        public static async Task<IReadOnlyList<IssueEx>> GetAllForCurrentWithComments(this IIssuesClient client, IssueRequest request)
        {
            var issues = await client.GetAllForCurrent(request);

            return await Task.WhenAll(issues.Select(async i => IssueEx.FromIssue(i, await client.Comment.GetAllForIssue(i.Url.Segments[2], i.Url.Segments[3], i.Number))));
        }

        public static async Task<IReadOnlyList<IssueEx>> GetAllForOrganizationWithComments(this IIssuesClient client, string organization)
        {
            var issues = await client.GetAllForOrganization(organization);

            return await Task.WhenAll(issues.Select(async i => IssueEx.FromIssue(i, await client.Comment.GetAllForIssue(i.Url.Segments[2], i.Url.Segments[3], i.Number))));
        }

        public static async Task<IReadOnlyList<IssueEx>> GetAllForOrganizationWithComments(this IIssuesClient client, string organization, IssueRequest request)
        {
            var issues = await client.GetAllForOrganization(organization, request);

            return await Task.WhenAll(issues.Select(async i => IssueEx.FromIssue(i, await client.Comment.GetAllForIssue(i.Url.Segments[2], i.Url.Segments[3], i.Number))));
        }

        public static async Task<IReadOnlyList<IssueEx>> GetAllForOwnedAndMemberRepositoriesWithComments(this IIssuesClient client)
        {
            var issues = await client.GetAllForOwnedAndMemberRepositories();

            return await Task.WhenAll(issues.Select(async i => IssueEx.FromIssue(i, await client.Comment.GetAllForIssue(i.Url.Segments[2], i.Url.Segments[3], i.Number))));
        }

        public static async Task<IReadOnlyList<IssueEx>> GetAllForOwnedAndMemberRepositoriesWithComments(this IIssuesClient client, IssueRequest request)
        {
            var issues = await client.GetAllForOwnedAndMemberRepositories(request);

            return await Task.WhenAll(issues.Select(async i => IssueEx.FromIssue(i, await client.Comment.GetAllForIssue(i.Url.Segments[2], i.Url.Segments[3], i.Number))));
        }

        public static async Task<IReadOnlyList<IssueEx>> GetAllForRepositoryWithComments(this IIssuesClient client, string owner, string name)
        {
            var issues = await client.GetAllForRepository(owner, name);

            return await Task.WhenAll(issues.Select(async i => IssueEx.FromIssue(i, await client.Comment.GetAllForIssue(owner, name, i.Number))));
        }
        public static async Task<IReadOnlyList<IssueEx>> GetAllForRepositoryWithComments(this IIssuesClient client, string owner, string name, RepositoryIssueRequest request)
        {
            var issues = await client.GetAllForRepository(owner, name, request);

            return await Task.WhenAll(issues.Select(async i => IssueEx.FromIssue(i, await client.Comment.GetAllForIssue(owner, name, i.Number))));
        }
    }
}
