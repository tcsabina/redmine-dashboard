using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Specialized;

namespace redmine_dashboard.Pages
{
    public class IndexModel : PageModel
    {
        public List<string>? IssueDetails { get; set; }

        public void OnGet()
        {
            string host = "http://127.0.0.1/";
            string apiKey = "8c2c0c5e67d6c424d6aa02ead559392d7570d2d7";
            IssueDetails = new List<string>();

            var manager = new RedmineManager(host, apiKey);

            var parameters = new NameValueCollection { { RedmineKeys.STATUS_ID, RedmineKeys.ALL } };

            foreach (var issue in manager.GetObjects<Issue>(parameters))
            {
                IssueDetails.Add($"#{issue.Id} | {issue.Status.Name} | {issue.Subject}");
            }
        }
    }
}
