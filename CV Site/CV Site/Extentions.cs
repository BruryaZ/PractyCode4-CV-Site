using Core.Models;
using Core.Services;
using Services;

namespace CV_Site
{
    public static class Extentions
    {
        public static void AddGitHubIntegartion(this IServiceCollection services, Action<GitHubIntegrationOptions> action)
        {
            services.Configure(action);
            services.AddScoped<IGitHubService, GitHubService>();
        }
    }
}
