using System;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace SolicitorCompare.Models
{
  public class SearchModel : ContentModel
  {
    public DateTime AccidentDate { get; set; }
    public string Fault { get; set; }
    public bool Passengers { get; set; }
    public string Damage { get; set; }
    public bool Minors { get; set; }
    public bool Hospital { get; set; }
    public bool Obscure { get; set; }
    public string Compensation { get; set; }

    public SearchModel(IPublishedContent content) : base(content)
    {
    }
  }
}
