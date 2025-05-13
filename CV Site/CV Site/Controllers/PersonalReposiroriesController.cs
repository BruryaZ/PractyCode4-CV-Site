using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace CV_Site.Controllers
{

    [Controller]
    [Route("[Controller]")]
    public class PersonalReposiroriesController(IGitHubService gitHubService) : ControllerBase
    {
        private readonly IGitHubService _githubService = gitHubService;
        [HttpGet("by-user-name")]
        public Task<IReadOnlyList<Repository>> GetPortfolio()
        {
            return _githubService.GetPortfolio();
        }

        [HttpGet("by-criterion")]
        public Task<IReadOnlyList<Repository>> SearchRepositories(string? userName, string? repoName, string? language)
        {
            return _githubService.SearchRepositories(userName, repoName, language);
        }
    }
}