using Octokit;

namespace GitHub.Core.Services
{
    public interface IGitHubService
    {
        Task<IReadOnlyList<Repository>> GetRepositories(string username);
    }
}