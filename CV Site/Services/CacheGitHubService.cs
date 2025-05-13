using Core.Services;
using Microsoft.Extensions.Caching.Memory;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CacheGitHubService(IGitHubService gitHubService, IMemoryCache memoryCache) : IGitHubService
    {
        private readonly IGitHubService _gitHubService = gitHubService;
        private readonly IMemoryCache _cache = memoryCache;
        private const string userPortfolioKey = "userPortdolioKey";
        public async Task<IReadOnlyList<Repository>> GetPortfolio()
        {
            if(_cache.TryGetValue(userPortfolioKey, out IReadOnlyList<Repository> cachedPortfolio))
                return cachedPortfolio;

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                .SetSlidingExpiration(TimeSpan.FromSeconds(10));

            cachedPortfolio = await _gitHubService.GetPortfolio();
            _cache.Set(userPortfolioKey, cachedPortfolio, cacheOptions);

            return cachedPortfolio;
        }

        public async Task<IReadOnlyList<Repository>> SearchRepositories(string? userName, string? repoName, string? language)
        {
            return await _gitHubService.SearchRepositories(userName, repoName, language);
        }
    }
}
