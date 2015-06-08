using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace IssuesManagment
{
    public class IssueEx : Issue
    {
        public IReadOnlyList<IssueCommentEx> FullComments { get; set; }

        public IssueEx()
            : this(new List<IssueCommentEx>())
        {
        }

        public IssueEx(IEnumerable<IssueCommentEx> comments)
        {
            FullComments = comments.ToList();

        }

        public IssueEx(IEnumerable<IssueComment> comments)
        {
            FullComments = comments.Select(c => IssueCommentEx.FromIssueComment(c)).ToList();

        }

        public static IssueEx FromIssue(Issue issue, IEnumerable<IssueCommentEx> comments)
        {
            return new IssueEx(comments) 
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

        public static IssueEx FromIssue(Issue issue, IEnumerable<IssueComment> comments)
        {
            return new IssueEx(comments)
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
