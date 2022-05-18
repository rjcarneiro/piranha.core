using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using Piranha.Models;
using MvcWeb.Models;

namespace MvcWeb.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SetupController : Controller
    {
        private readonly IApi _api;
        private readonly IModelLoader _loader;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        public SetupController(IApi api, IModelLoader loader)
        {
            _api = api;
            _loader = loader;
        }

        /// <summary>
        /// Gets the blog archive with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="year">The optional year</param>
        /// <param name="month">The optional month</param>
        /// <param name="page">The optional page</param>
        /// <param name="category">The optional category</param>
        /// <param name="tag">The optional tag</param>
        /// <param name="draft">If a draft is requested</param>
        [Route("seed")]
        public async Task<IActionResult> Seeder()
        {
            try
            {
                await Seed.RunAsync(_api);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }

            return Redirect("~/");
        }

    }
}
