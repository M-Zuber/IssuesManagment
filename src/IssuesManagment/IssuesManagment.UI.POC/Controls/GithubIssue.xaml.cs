using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Octokit;

namespace IssuesManagment.UI.POC.Controls
{
    /// <summary>
    /// Interaction logic for GithubIssue.xaml
    /// </summary>
    public partial class GithubIssue : UserControl
    {
        public GithubIssue(IssueWithComments issue)
        {
            InitializeComponent();
            this.DataContext = issue;

            var commentDisplayers = new List<GithubIssueComment>();
            foreach (var comment in issue.Comments)
            {
                commentDisplayers.Add(new GithubIssueComment(comment));
            }
            comments.ItemsSource = commentDisplayers;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
