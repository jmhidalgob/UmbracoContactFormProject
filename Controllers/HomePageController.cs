using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Infrastructure.Scoping;

namespace UmbracoContactFormProject.Controllers;

public class HomePageController : RenderController
{

    private readonly IScopeProvider _scopeProvider;

    public HomePageController(
        ILogger<HomePageController> logger,
        ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor,
        IScopeProvider scopeProvider)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _scopeProvider = scopeProvider;
    }

    public override IActionResult Index()
    {
        Console.WriteLine("Hijacking route requests to ProductPageController.Index");
        // return a 'model' to the selected template/view for this page.
        return CurrentTemplate(CurrentPage);
    }
}