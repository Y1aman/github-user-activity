using GithubUserActivity;

var service = new GitHubService();

while (true)
{
    Console.Write("Enter GitHub username (or type 'exit' to quit): ");
    string username = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(username))
    {
        Console.WriteLine("Username cannot be empty.");
        continue;
    }

    if (username.ToLower() == "exit")
        break;

    var activities = await service.GetUserActivityAsync(username);

    Console.WriteLine($"\nLast Activities for user: {username}\n");

    if (activities.Count == 0)
    {
        Console.WriteLine("No activities found or user does not exist.\n");
    }
    else
    {
        foreach (var activity in activities)
        {
            Console.WriteLine($"Type: {activity.Type}");
            Console.WriteLine($"Repository: {activity.RepoName}");
            Console.WriteLine($"Created At: {activity.CreatedAt}");
            Console.WriteLine("---------------------------");
        }
    }

    Console.WriteLine("Press Enter to check another user, or type 'exit' to quit.");
    string input = Console.ReadLine();
    if (input.ToLower() == "exit")
        break;
}
