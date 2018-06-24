using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExcersize
{
    public class SearchGitHubClient
    {
        public static IEnumerable<RepoResult>  SearchRepositories(string term)
        {
            var client = new GitHubClient(new ProductHeaderValue("SearchGitHub"));

            var request = new SearchRepositoriesRequest("bootstrap");

            var itms =  client.Search.SearchRepo(request).Result.Items.ToList() ;
         return   itms.Select(x => new RepoResult {Name= x.FullName ,Owner =  x.Owner.Login   });
        }
    }
    public class RepoResult
    {
        public string Name { get; set; }
        public string Owner { get; set; }
    }
}
