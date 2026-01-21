using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Infrastructure.Scoping;
using UmbracoContactFormProject.Models;
using UmbracoContactFormProject.Persistence;

namespace UmbracoContactFormProject.Components;

public class ContactListViewComponent : ViewComponent
{
    private readonly IScopeProvider _scopeProvider;

    public ContactListViewComponent(IScopeProvider scopeProvider)
    {
        _scopeProvider = scopeProvider;
    }

    public IViewComponentResult Invoke(int maxItems = 10) // Default to 10 items
    {   
        Console.WriteLine("ENTRA EN EL COMPONENTE ContactListViewComponent" +
            " para obtener los últimos " + maxItems + " mensajes de contacto.");

        using var scope = _scopeProvider.CreateScope();
        var messages = scope.Database.Fetch<ContactMessageSchema>(
            "SELECT * FROM ContactMessages ORDER BY CreateDate DESC LIMIT @0", maxItems
        );
        scope.Complete();

        return View(messages); // Esto busca una vista en View/Shared/Components/ContactList/Default.cshtml
    }
}