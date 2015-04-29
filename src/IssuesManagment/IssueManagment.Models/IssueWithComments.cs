using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace IssuesManagment
{
    public class IssueWithComments
    {
        public Issue Issue { get; set; }

        public IReadOnlyList<IssueComment> Comments { get; set; }

        public IssueWithComments()
        {
            Comments = new List<IssueComment>();
        }
    }
}
