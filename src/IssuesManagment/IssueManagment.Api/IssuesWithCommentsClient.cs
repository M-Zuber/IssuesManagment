using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
namespace IssuesManagment.Clients
{
    public class IssuesWithCommentsClient : IssuesClient
    {
        public IssuesWithCommentsClient(IApiConnection connection)
            : base(connection)
        {

        }

        public async Task<IssueWithComments> GetWithComments(string owner, string name, int number)
        {
            var issue = await base.Get(owner, name, number);
            var comments = await base.Comment.GetAllForIssue(owner, name, issue.Number);

            return new IssueWithComments { Issue = issue, Comments = comments };
        }

        public async Task<IReadOnlyList<IssueWithComments>> GetAllForCurrentWithComments()
        {
            var issues = await base.GetAllForCurrent();

            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(new IssueWithComments { Issue = i, Comments = await base.Comment.GetAllForIssue(owner, repo, i.Number) });
                }
            }

            return all.AsReadOnly();
        }

        public async Task<IReadOnlyList<IssueWithComments>> GetAllForCurrentWithComments(IssueRequest request)
        {
            var issues = await base.GetAllForCurrent(request);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(new IssueWithComments { Issue = i, Comments = await base.Comment.GetAllForIssue(owner, repo, i.Number) });
                }
            }

            return all.AsReadOnly();
        }

        public async Task<IReadOnlyList<IssueWithComments>> GetAllForOrganizationWithComments(string organization)
        {
            var issues = await base.GetAllForOrganization(organization);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(new IssueWithComments { Issue = i, Comments = await base.Comment.GetAllForIssue(owner, repo, i.Number) });
                }
            }

            return all.AsReadOnly();
        }

        public async Task<IReadOnlyList<IssueWithComments>> GetAllForOrganizationWithComments(string organization, IssueRequest request)
        {
            var issues = await base.GetAllForOrganization(organization, request);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(new IssueWithComments { Issue = i, Comments = await base.Comment.GetAllForIssue(owner, repo, i.Number) });
                }
            }

            return all.AsReadOnly();
        }

        public async Task<IReadOnlyList<IssueWithComments>> GetAllForOwnedAndMemberRepositoriesWithComments()
        {
            var issues = await base.GetAllForOwnedAndMemberRepositories();
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(new IssueWithComments { Issue = i, Comments = await base.Comment.GetAllForIssue(owner, repo, i.Number) });
                }
            }

            return all.AsReadOnly();
        }

        public async Task<IReadOnlyList<IssueWithComments>> GetAllForOwnedAndMemberRepositoriesWithComments(IssueRequest request)
        {
            var issues = await base.GetAllForOwnedAndMemberRepositories(request);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var group in groupedIssues)
            {
                var owner = group.Key.Segments[2];
                var repo = group.Key.Segments[3];
                foreach (var i in group)
                {
                    all.Add(new IssueWithComments { Issue = i, Comments = await base.Comment.GetAllForIssue(owner, repo, i.Number) });
                }
            }

            return all.AsReadOnly();
        }

        public async Task<IReadOnlyList<IssueWithComments>> GetAllForRepositoryWithComments(string owner, string name)
        {
            var issues = await base.GetAllForRepository(owner, name);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var i in issues)
            {
                all.Add(new IssueWithComments { Issue = i, Comments = await base.Comment.GetAllForIssue(owner, name, i.Number) });
            }

            return all.AsReadOnly();
        }

        public async Task<IReadOnlyList<IssueWithComments>> GetAllForRepositoryWithComments(string owner, string name, RepositoryIssueRequest request)
        {
            var issues = await base.GetAllForRepository(owner, name, request);
            List<IssueWithComments> all = new List<IssueWithComments>();

            var groupedIssues = issues.GroupBy(i => i.Url);

            foreach (var i in issues)
            {
                all.Add(new IssueWithComments { Issue = i, Comments = await base.Comment.GetAllForIssue(owner, name, i.Number) });
            }

            return all.AsReadOnly();
        }
    }
}
