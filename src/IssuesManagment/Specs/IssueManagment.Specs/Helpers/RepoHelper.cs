using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace IssueManagment.Specs.Helpers
{
    public static class RepoHelper
    {
        public static string MakeNameWithTimestamp(string name)
        {
            return string.Concat(name, "-", DateTime.UtcNow.ToString("yyyyMMddhhmmssfff"));
        }

        public static void DeleteRepo(Repository repository)
        {
            if (repository != null)
                DeleteRepo(repository.Owner.Login, repository.Name);
        }

        public static void DeleteRepo(string owner, string name)
        {
            var api = AuthHelper.GetAuthenticatedClient();
            try
            {
                api.Repository.Delete(owner, name).Wait(TimeSpan.FromSeconds(15));
            }
            catch { }
        }
    }
}
