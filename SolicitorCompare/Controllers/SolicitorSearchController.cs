using System;
using System.Web.Mvc;
using SolicitorCompare.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace SolicitorCompare.Controllers
{
  public class SolicitorSearchController : RenderMvcController
  {
    public new ActionResult Index(ContentModel model)
    {
      var searchModel = new SearchModel(model.Content);

      return View("SolicitorSearch", searchModel);
    }
  }
}
