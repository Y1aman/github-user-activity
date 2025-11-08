using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;



namespace GithubUserActivity;

public class GitHubService
{
    private readonly HttpClient _client = new HttpClient();

    public GitHubService()
    {
        _client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");
    }

    public async Task<List<Activity>> GetUserActivityAsync(string username)
    {
        string url = "https://api.github.com/users/" + username + "/events";
        var response = await _client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Error: " + response.StatusCode);
            return new List<Activity>();
        }

        string json = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(json);
        var activities = new List<Activity>();
        foreach (var element in doc.RootElement.EnumerateArray())
        {
            var type = element.GetProperty("type").GetString();
            var repoName = element.GetProperty("repo").GetProperty("name").GetString();
            var createdAt = element.GetProperty("created_at").GetDateTime();

            activities.Add(new Activity
            {
                Type = type,
                RepoName = repoName,
                CreatedAt = createdAt
            });
        }
        return activities;
    }
}
