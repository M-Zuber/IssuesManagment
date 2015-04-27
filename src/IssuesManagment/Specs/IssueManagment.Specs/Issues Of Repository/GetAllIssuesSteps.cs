using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IssueManagment.Specs.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octokit;
using TechTalk.SpecFlow;
using System.Linq;

namespace IssueManagment.Specs
{
    [Binding]
    public class GetAllIssuesSteps
    {
        private IGitHubClient _githubClient;
        private Repository _repo;
        private IIssuesClient _issuesClient;

        [Given(@"An authenticated user")]
        public async Task AnAuthenticatedUser()
        {
            _githubClient = MockingHelper.GetAuthenticatedClient();
        }

        [Given(@"the repository")]
        public async Task GivenTheRepository(Table table)
        {
            var repoName = MockingHelper.MakeNameWithTimestamp(table.Rows[0]["reponame"]);
            _repo = await _githubClient.Repository.Create(new NewRepository(repoName));
            _issuesClient = _githubClient.Issue;
        }

        [Given(@"the issues")]
        public async Task GivenTheIssues(Table table)
        {
            string owner = _repo.Owner.Login;

            NewIssue newIssue;
            foreach (var item in table.Rows)
            {
                newIssue = new NewIssue(item["title"]) { Body = item["body"] };
                var issue = await _issuesClient.Create(owner, _repo.Name, newIssue);
                await _issuesClient.Update(owner, _repo.Name, issue.Number, new IssueUpdate { State = EnumExtensions.Parse<ItemState>(item["state"], true) });
            }
        }

        [When(@"I request the issues for repository ""(.*)""")]
        public async Task WhenIRequestTheIssuesForRepository(string p0)
        {
            var issues = await _issuesClient.GetAllForRepository(_repo.Owner.Login, _repo.Name);
            ScenarioContext.Current.Add("issues", issues);
        }

        [Then(@"all the issues in the list have the state ""(.*)""")]
        public async Task ThenAllTheIssuesInTheListHaveTheState(string p0)
        {
            var issuesList = ScenarioContext.Current.Get<IReadOnlyList<Issue>>("issues");

            Assert.IsTrue(issuesList.All(i => i.State == ItemState.Open));
        }

        [When(@"I request all the issues for repository ""(.*)""")]
        public async Task WhenIRequestAllTheIssuesForRepository(string p0)
        {
            var issues = await _issuesClient.GetAllForRepository(_repo.Owner.Login, _repo.Name, new RepositoryIssueRequest { State = ItemState.All });
            ScenarioContext.Current.Add("issues", issues);
        }

        [Then(@"the issues vary in state")]
        public async Task ThenTheIssuesVaryInState()
        {
            var issuesList = ScenarioContext.Current.Get<IReadOnlyList<Issue>>("issues");

            Assert.IsTrue(issuesList.Any(i => i.State == ItemState.Closed) && issuesList.Any(i => i.State == ItemState.Open));
        }


        [AfterScenario]
        private void CleanUp()
        {
            MockingHelper.DeleteRepo(_repo);
        }
    }
}
