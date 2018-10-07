using Documentation.Plugin.Interfaces;
using Documentation.Plugin.Models;
using EPiServer;
using EPiServer.Core;
using System;
using System.Web.Mvc;
using Documentation.Plugin.Core.Interfaces;

namespace Documentation.Plugin.Controllers
{
    public class EditorViewDocumentationController : Controller
    {
        private readonly IContentRepository _contentRepository;
        private readonly IDocumentationRepository _documentationRepository;

        public EditorViewDocumentationController(IContentRepository contentRepository, IDocumentationRepository documentRepository)
        {
            _contentRepository = contentRepository;
            _documentationRepository = documentRepository;
        }

        public ActionResult Index()
        {
            var model = new EditorViewDocumentationViewModel();

            try
            {
                //Get the episerver content id from the query string
                var epiId = System.Web.HttpContext.Current.Request.QueryString["id"];

                //Gets the current content based on the id
                IDocumented currentContent = _contentRepository.Get<ContentData>(new ContentReference(epiId)) as IDocumented;
                
                //if currentContent doesnt implement IDocumented 
                if (currentContent == null)
                {
                    model.DocumentationContent = "<p>Current content does not support documentation view</p>";
                    return View(model);
                }

                //Grab the documentation markup
                var result = _documentationRepository.GetDocumentationById(currentContent.DocumentationReference);
                if (!string.IsNullOrEmpty(result))
                {
                    model.DocumentationContent = result;
                }
                else
                {
                    model.DocumentationContent = $"<p>No documentation exists for: {currentContent.DocumentationReference}</p>";
                }
            }
            catch (Exception e)
            {
                model.DocumentationContent = $"<p>Error getting documentation: {e.Message}</p>";
            }

            return View(model);
        }
    }
}
