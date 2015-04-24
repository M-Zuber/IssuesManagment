using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;

namespace IssuesManagment.UI.POC
{
    public partial class Issue : UserControl
    {
        private Octokit.Issue _issue;

        public Issue(Octokit.Issue issue)
        {
            _issue = issue;
            InitializeComponent();
            RenderIssue();
        }

        private void RenderIssue()
        {
            IssueTitle.Text = _issue.Title;
            IssueBody.Text = _issue.Body;
            this.Height += IssueBody.Height;
        }
    }
}
