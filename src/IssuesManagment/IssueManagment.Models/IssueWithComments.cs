using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace IssuesManagment
{
    public class IssueWithComments : Issue
    {
        public IReadOnlyList<IssueComment> FullComments { get; set; }

        public IssueWithComments()
            : this(new List<IssueComment>())
        {
        }

        public IssueWithComments(IEnumerable<IssueComment> comments)
        {
            FullComments = comments.ToList();

        }

        public static IssueWithComments FromIssue(Issue issue, IEnumerable<IssueComment> comments)
        {
            return new IssueWithComments(comments) 
            {
                Assignee = issue.Assignee,
                Body = issue.Body,
                ClosedAt = issue.ClosedAt,
                Comments = issue.Comments,
                CreatedAt = issue.CreatedAt,
                HtmlUrl = issue.HtmlUrl,
                Labels = issue.Labels,
                Milestone = issue.Milestone,
                Number = issue.Number,
                PullRequest = issue.PullRequest,
                State = issue.State,
                Title = issue.Title,
                UpdatedAt = issue.UpdatedAt,
                Url = issue.Url,
                User = issue.User
            };
        }
    }
}
