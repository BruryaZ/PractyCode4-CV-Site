using GitHub.Core.Services;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.services
{
    public class GitHubService : IGitHubService
    {
        private readonly GitHubClient _client;
        public GitHubService()
        {
            _client = new GitHubClient(new ProductHeaderValue("GitHubService"));
        }

        public Task<IReadOnlyList<Repository>> GetRepositories(string username)
        {
            return _client.Repository.GetAllForUser(username);
        }

        //public async Task<int> GetUserFollowerAsync(string username)
        //{
        //    var user = await _client.User.Get(username);
        //    return user.Followers;
        //}
        //public async Task<IReadOnlyList<Repository>> GetRepositories(string username)
        //{
        //    var repositories = await _client.Repository.GetAllForUser(username);
        //    return repositories;
        //}
    }
}
