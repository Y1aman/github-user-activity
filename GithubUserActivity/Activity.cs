using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GithubUserActivity;

namespace GithubUserActivity
{
    public class Activity
    {
        public string Type { get; set; }
        public string RepoName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
