using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace IssuesManagment
{
    public class IssueCommentEx : IssueComment
    {
        public static IssueCommentEx FromIssueComment(IssueComment c)
        {
            return new IssueCommentEx
            {
                Id = c.Id,
                Body = c.Body,
                CreatedAt = c.CreatedAt,
                HtmlUrl = c.HtmlUrl,
                UpdatedAt = c.UpdatedAt,
                Url = c.Url,
                User = c.User
            };
        }
        public int IssueNumber
        {
            get
            {
                return int.Parse(HtmlUrl.Segments[4]);
            }
        }
    }
}
