using GitHub.Core.Services;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace CV_Site.Controllers
{
    [Route("[controller]")]//TODO
    [ApiController]
    public class PersonalReposiroriesController(IGitHubService gitHubService) : ControllerBase
    {
        private readonly IGitHubService _githubService = gitHubService;
        [HttpGet]
        public Task<IReadOnlyList<Repository>> Get(string userName)
        {
            return _githubService.GetRepositories(userName);
        }

        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
