using System;
using System.Collections.Generic;
using System.Linq;
using SolicitorCompare.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace SolicitorCompare.Helpers
{
  public class SolicitorSearchHelper
  {
    public List<IPublishedContent> GetRTASolicitorResults(SearchModel model)
    {
      var results = new List<IPublishedContent>();

      var umbracoHelper = Umbraco.Web.Composing.Current.UmbracoHelper;
      var solicitors = umbracoHelper.ContentSingleAtXPath(XPath.SolicitorListing).Children.ToList();

      foreach (var solicitor in solicitors)
      {
        var maxMonths = solicitor.Value<int?>("maximumMonthsSinceIncident");
        if (maxMonths == null)
        {
          maxMonths = 18;
        }

        var monthsApart = Math.Abs(12 * (model.AccidentDate.Year - DateTime.Today.Year) + model.AccidentDate.Month - DateTime.Today.Month);
        if (monthsApart > maxMonths)
        {
          continue;
        }

        if (!model.Hospital && !solicitor.Value<bool>("medicalAttention"))
        {
          continue;
        }

        if (model.Minors && !solicitor.Value<bool>("minors"))
        {
          continue;
        }

        if (model.Obscure && !solicitor.Value<bool>("obscureLocation"))
        {
          continue;
        }

        bool fault = model.Fault.ToLower() == "yes";

        if (fault && !solicitor.Value<bool>("passengersAndAtFault"))
        {
          continue;
        }

        if (fault && !model.Passengers && solicitor.Value<bool>("passengersAndAtFault"))
        {
          continue;
        }

        bool damage = model.Damage.ToLower() == "yes";

        if (!damage && !solicitor.Value<bool>("damage"))
        {
          continue;
        }

        bool compensation = model.Compensation.ToLower() == "yes";

        if (compensation && !solicitor.Value<bool>("compensation"))
        {
          continue;
        }

        results.Add(solicitor);
      }

      return results;
    }

    public List<IPublishedContent> GetConveyanceSolicitorResults()
    {
      var results = new List<IPublishedContent>();
      var umbracoHelper = Umbraco.Web.Composing.Current.UmbracoHelper;
      var solicitors = umbracoHelper.ContentSingleAtXPath(XPath.SolicitorListing).Children.ToList();


      results = solicitors.Where(s => s.Value<string[]>("services").Contains("Conveyancing")).ToList();

      return results;
    }
  }
}
