using Octokit;

namespace GitHub.services
{
    public interface IGitHubService
    {
        Task<int> GetUserFollowerAsync(string username);
        Task<IReadOnlyList<Repository>> GetRepositories(string username);
    }
}