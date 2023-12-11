using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MockCrestronApi.Pages
{
    public class console : PageModel
    {
        public void OnGet()
        {
            Response.Headers.Add("Token", "qwoeiuqpweruadlkfjasdflkjasdf");
        }
    }
}
