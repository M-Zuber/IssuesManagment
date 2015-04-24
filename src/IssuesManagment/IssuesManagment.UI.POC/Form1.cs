using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssuesManagment.UI.POC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void GetIssues_Click(object sender, EventArgs e)
        {
            var apiClient = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("Issue-Managment"));
            var issues = await apiClient.Issue.GetAllForRepository("m-zuber", "myhome");

            int nextTop = this.Issues.Top + 10;
            int width = this.Issues.Width;

            foreach (var issue in issues)
            {
                var displayer = new Issue(issue);

                displayer.Top = nextTop;
                displayer.Width = width;
                nextTop = displayer.Bottom + 2;

                this.Issues.Controls.Add(displayer);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Issues.Controls.OfType<Control>().ToList().ForEach(c => c.Width = this.Width);

            this.Issues.Height = (this.Height * 90) / 100;

            this.GetIssues.Top = this.Issues.Bottom + 15;
        }
    }
}
