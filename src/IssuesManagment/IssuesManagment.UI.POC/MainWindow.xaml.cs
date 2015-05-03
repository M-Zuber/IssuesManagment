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
using IssuesManagment.Clients;
using IssuesManagment.UI.POC.Controls;

namespace IssuesManagment.UI.POC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ViewIssues_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            var apiClient = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("Issue-Managment"));
            if (!string.IsNullOrWhiteSpace(userName.Text) && !string.IsNullOrWhiteSpace(repoName.Text))
            {
                var issuesClient = new IssuesWithCommentsClient(new Octokit.ApiConnection(apiClient.Connection));
                var issues = await issuesClient.GetAllForRepositoryWithComments(userName.Text, repoName.Text);

                GithubIssue x;
                foreach (var item in issues)
                {
                    x = new GithubIssue(item);
                    grid.Children.Add(x);
                }
            }
            else
            {
                grid.Children.Add(new Controls.Error());
            }
        }
    }
}
