using Microsoft.AspNetCore.Mvc;
using UmbracoContactFormProject.Models;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging; 
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Core.Scoping;

namespace UmbracoContactFormProject.Controllers;

public class ContactFormController : SurfaceController
{

    private readonly IScopeProvider _scopeProvider;

    public ContactFormController(
        IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services,
        AppCaches appCaches,
        IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider,
        IScopeProvider scopeProvider) 
        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        _scopeProvider = scopeProvider;
    }

    [HttpPost]
    public IActionResult Submit(ContactFormViewModel model)
    {

        Console.WriteLine("ENTRA EN EL CONTROLLER");
        Console.WriteLine("model.Name: " + model.Name);
        Console.WriteLine("model.Email: " + model.Email);
        Console.WriteLine("model.Message: " + model.Message);

        Console.WriteLine("ModelState.IsValid: " + ModelState.IsValid);

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Formulario no válido - retornando a la página actual");
            return CurrentUmbracoPage();
        }
        

        // GUARDAR EN BASE DE DATOS
        using (var scope = _scopeProvider.CreateScope())
        {
            var entity = new ContactMessageSchema
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message,
                CreateDate = DateTime.Now
            };

            scope.Database.Insert(entity);
            scope.Complete();
        }

        TempData["Success"] = true;

        return RedirectToCurrentUmbracoPage();
    }
}