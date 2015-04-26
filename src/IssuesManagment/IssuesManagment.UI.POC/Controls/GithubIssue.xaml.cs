﻿using System;
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
    /// Interaction logic for GithubIssue.xaml
    /// </summary>
    public partial class GithubIssue : UserControl
    {
        public GithubIssue(Issue issue)
        {
            InitializeComponent();
            this.DataContext = issue;
        }
    }
}