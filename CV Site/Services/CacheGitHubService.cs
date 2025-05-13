using Core.Services;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CacheGitHubService(IGitHubService gitHubService) : IGitHubService
    {
        private readonly IGitHubService _gitHubService = gitHubService;
        public async Task<IReadOnlyList<Repository>> GetRepositories(string username)
        {
            return await _gitHubService.GetRepositories(username);
        }

        public async Task<IReadOnlyList<Repository>> SearchRepositories(string? userName, string? repoName, string? language)
        {
            return await _gitHubService.SearchRepositories(userName, repoName, language);
        }
    }
}
