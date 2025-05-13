using Core.Services;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GitHubService : IGitHubService
    {
        private readonly GitHubClient _client;
        public GitHubService()
        {
            _client = new GitHubClient(new ProductHeaderValue("GitHubService"));
        }

        public async Task<IReadOnlyList<Repository>> GetPortfolio(string username)
        {
            return await _client.Repository.GetAllForUser(username);
        }

        public async Task<IReadOnlyList<Repository>> SearchRepositories(string? userName, string? repoName, string? language)
        {
            var queryParts = new List<string>();

            if (!string.IsNullOrWhiteSpace(repoName))
                queryParts.Add($"{repoName} in:name");

            if (!string.IsNullOrWhiteSpace(language))
                queryParts.Add($"language:{language}");

            if (!string.IsNullOrWhiteSpace(userName))
                queryParts.Add($"user:{userName}");

            var query = string.Join(" ", queryParts);

            var request = new SearchRepositoriesRequest(query)
            {
                SortField = RepoSearchSort.Updated,
                Order = SortDirection.Descending
            };

            var res = await _client.Search.SearchRepo(request);
            return res.Items;
        }
    }
}