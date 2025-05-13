using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IGitHubService
    {
        Task<IReadOnlyList<Repository>> GetRepositories(string username);

        Task<IReadOnlyList<Repository>> SearchRepositories(string? userName, string? repoName, string? language);
    }
}
