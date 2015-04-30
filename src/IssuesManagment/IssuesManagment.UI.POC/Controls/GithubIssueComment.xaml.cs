using System;
using System.Collections.Generic;
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
    /// Interaction logic for GithubIssueComment.xaml
    /// </summary>
    public partial class GithubIssueComment : UserControl
    {
        public GithubIssueComment(IssueComment comment)
        {
            InitializeComponent();
            this.DataContext = comment;
        }
    }
}
